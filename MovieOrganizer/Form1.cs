using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace MovieOrganizer
{
    public partial class Form1 : Form
    {
        private static Collection<Movie> allMovies;
        private static IMovieDAL movieDAL;
        private static string[] supportedFileTypes = ConfigurationSettings.AppSettings["fileTypes"].Split(',');

        public Form1()
        {
            InitializeComponent();
            allMovies = new Collection<Movie>();
            movieDAL = new RottenTomatoesDAL();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdFindMovie.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofdFindMovie.FileName);
                AddMovieToGrid(file);
            }
        }

        private void AddMovieToGrid(FileInfo file)
        {
            if (supportedFileTypes.Contains(file.Extension.ToLower()))
            {
                Movie movie = new Movie();
                movie.title = file.Name.Replace(file.Extension, String.Empty);
                movie.file = file;
                movie.genres = movieDAL.getGenres(movie.title);
                allMovies.Add(movie);
                gridShowMovies.Rows.Add();
                int rowIndex = gridShowMovies.Rows.Count - 1;
                DataGridViewRow row = gridShowMovies.Rows[rowIndex];
                gridShowMovies.Rows[rowIndex].Cells[0].Value = movie.title;
                if (movie.genres.Count > 0)
                {
                    DataGridViewComboBoxCell dgvcb = (DataGridViewComboBoxCell)gridShowMovies.Rows[rowIndex].Cells[1];
                    foreach (string genre in movie.genres)
                    {
                        dgvcb.Items.Add(genre);
                    }
                    dgvcb.DisplayMember = "this";
                    dgvcb.ValueMember = "this";
                }
                else
                {
                    SetRowStatus(row, "Could not find Movie");
                }
            }
            else
            {
                MessageBox.Show("Unsupported File Type: " + file.Name);
            }
        }

        private void SetRowStatus(DataGridViewRow row, string message)
        {
            row.Cells["colStatus"].Value = message;
        }

        private void SetRowPath(DataGridViewRow row, string path)
        {
            row.Cells["colNewPath"].Value = path;
        }

        private void btnOrganize_Click(object sender, EventArgs e)
        {
            progBarOrgProgress.Value = 0;
            int totalMovies = gridShowMovies.RowCount;
            int percentageMultiplier = progBarOrgProgress.Maximum / totalMovies;
            progBarOrgProgress.Step = percentageMultiplier;
            foreach (DataGridViewRow row in gridShowMovies.Rows)
            {
                Movie movie = allMovies[row.Index];
                DataGridViewComboBoxCell dgvcb = (DataGridViewComboBoxCell)row.Cells[1];
                bool genreSelected = !String.IsNullOrEmpty((string)dgvcb.Value);
                string newPath = String.Empty;
                StringBuilder sbNewPath = new StringBuilder();
                if (lblTopLevelPath.Text == "No Path Selected")
                {
                    sbNewPath.Append(movie.file.DirectoryName);
                }
                else
                {
                    sbNewPath.Append(lblTopLevelPath.Text);
                }
                sbNewPath.Append("\\");
                sbNewPath.Append(((string)dgvcb.Value).Trim());
                sbNewPath.Append("\\");
                if (!String.IsNullOrEmpty((string)row.Cells[2].Value))
                {
                    sbNewPath.Append(((string)row.Cells[2].Value).Trim());
                    if (!sbNewPath.ToString().EndsWith("\\"))
                    {
                        sbNewPath.Append("\\");
                    }
                }

                newPath = sbNewPath.ToString();
                if (cbCreateFolders.Checked && !Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                
                if (Convert.ToString(row.Cells[3].Value) == "Success!")
                {
                    gridShowMovies.Rows.Remove(row);
                }
                else if (Directory.Exists(newPath) && genreSelected)
                {
                    movie.file.MoveTo(newPath + "\\" + movie.file.Name);
                    SetRowStatus(row, "Success!");
                    SetRowPath(row, newPath);
                }
                else if (!genreSelected)
                {
                    SetRowStatus(row, "Genre Not Selected");
                }
                else
                {
                    SetRowStatus(row, "Path Doesn't Exist");
                    SetRowPath(row, newPath);
                }
                progBarOrgProgress.PerformStep();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int rows = gridShowMovies.RowCount;
            for (int i = 0; i < rows; i++)
            {
                gridShowMovies.Rows.RemoveAt(0);
            }
            progBarOrgProgress.Value = 0;
            lblTopLevelPath.Text = "No Path Selected";
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdFindMovie.ShowDialog();
            if (result == DialogResult.OK)
            {
                progBarOrgProgress.Value = 0;
                DirectoryInfo dir = new DirectoryInfo(fbdFindMovie.SelectedPath);
                int step = progBarOrgProgress.Maximum / dir.GetFiles().Length;
                progBarOrgProgress.Step = step;
                foreach (FileInfo file in dir.GetFiles())
                {
                    AddMovieToGrid(file);
                    progBarOrgProgress.PerformStep();
                }
            }
        }

        private void btnSelectTopLevel_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdMovieOrgPath.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblTopLevelPath.Text = fbdMovieOrgPath.SelectedPath;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine("Welcome to Movie Organizer!");
            helpMessage.AppendLine("Here is a quick tutorial on how to use this program:");
            helpMessage.AppendLine("1. Go to File and Add a Movie or a Folder. This will add the movie(s) to the grid, and find the genres using the Rotten Tomatoes API");
            helpMessage.AppendLine("2. Select the Genre you would like to organize each movie into. This will move the movie into a folder with the name of the selected Genre when the Organize Movies button is clicked");
            helpMessage.AppendLine("3. If you'd like, specify some sub-folders. For Example, if you have Toy Story 1-3 and would like to put them in a separate folder, just type in Toy Story");
            helpMessage.AppendLine("4. If you'd like, specify a top-level folder. This will organize all of the movies within the selected folder, a good example would be your regular Movies folder");
            helpMessage.AppendLine("5. Check the Create Folders check box if you want the program to create new folders to organize your movies into");
            helpMessage.AppendLine("6. Click the Organize Movies button! This will automatically organize all of the movies you selected a Genre for, it will also update you with the status of each movie.");
            MessageBox.Show(helpMessage.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
