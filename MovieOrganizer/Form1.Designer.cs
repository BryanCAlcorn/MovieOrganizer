namespace MovieOrganizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFindMovie = new System.Windows.Forms.OpenFileDialog();
            this.gridShowMovies = new System.Windows.Forms.DataGridView();
            this.btnOrganize = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.fbdFindMovie = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdMovieOrgPath = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTopLevelPath = new System.Windows.Forms.Label();
            this.btnSelectTopLevel = new System.Windows.Forms.Button();
            this.cbCreateFolders = new System.Windows.Forms.CheckBox();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenres = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSubFolders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progBarOrgProgress = new System.Windows.Forms.ProgressBar();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShowMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFileToolStripMenuItem,
            this.selectFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // selectFileToolStripMenuItem
            // 
            this.selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            resources.ApplyResources(this.selectFileToolStripMenuItem, "selectFileToolStripMenuItem");
            this.selectFileToolStripMenuItem.Click += new System.EventHandler(this.selectFileToolStripMenuItem_Click);
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            resources.ApplyResources(this.selectFolderToolStripMenuItem, "selectFolderToolStripMenuItem");
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ofdFindMovie
            // 
            this.ofdFindMovie.FileName = "openFileDialog1";
            // 
            // gridShowMovies
            // 
            this.gridShowMovies.AllowUserToAddRows = false;
            resources.ApplyResources(this.gridShowMovies, "gridShowMovies");
            this.gridShowMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShowMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colGenres,
            this.colSubFolders,
            this.colStatus,
            this.colNewPath});
            this.gridShowMovies.Name = "gridShowMovies";
            // 
            // btnOrganize
            // 
            resources.ApplyResources(this.btnOrganize, "btnOrganize");
            this.btnOrganize.Name = "btnOrganize";
            this.btnOrganize.UseVisualStyleBackColor = true;
            this.btnOrganize.Click += new System.EventHandler(this.btnOrganize_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTopLevelPath
            // 
            resources.ApplyResources(this.lblTopLevelPath, "lblTopLevelPath");
            this.lblTopLevelPath.Name = "lblTopLevelPath";
            // 
            // btnSelectTopLevel
            // 
            resources.ApplyResources(this.btnSelectTopLevel, "btnSelectTopLevel");
            this.btnSelectTopLevel.Name = "btnSelectTopLevel";
            this.btnSelectTopLevel.UseVisualStyleBackColor = true;
            this.btnSelectTopLevel.Click += new System.EventHandler(this.btnSelectTopLevel_Click);
            // 
            // cbCreateFolders
            // 
            resources.ApplyResources(this.cbCreateFolders, "cbCreateFolders");
            this.cbCreateFolders.Name = "cbCreateFolders";
            this.cbCreateFolders.UseVisualStyleBackColor = true;
            // 
            // colTitle
            // 
            resources.ApplyResources(this.colTitle, "colTitle");
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colGenres
            // 
            resources.ApplyResources(this.colGenres, "colGenres");
            this.colGenres.Name = "colGenres";
            // 
            // colSubFolders
            // 
            resources.ApplyResources(this.colSubFolders, "colSubFolders");
            this.colSubFolders.Name = "colSubFolders";
            // 
            // colStatus
            // 
            resources.ApplyResources(this.colStatus, "colStatus");
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colNewPath
            // 
            resources.ApplyResources(this.colNewPath, "colNewPath");
            this.colNewPath.Name = "colNewPath";
            // 
            // progBarOrgProgress
            // 
            resources.ApplyResources(this.progBarOrgProgress, "progBarOrgProgress");
            this.progBarOrgProgress.Name = "progBarOrgProgress";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progBarOrgProgress);
            this.Controls.Add(this.cbCreateFolders);
            this.Controls.Add(this.btnSelectTopLevel);
            this.Controls.Add(this.lblTopLevelPath);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOrganize);
            this.Controls.Add(this.gridShowMovies);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShowMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdFindMovie;
        private System.Windows.Forms.DataGridView gridShowMovies;
        private System.Windows.Forms.Button btnOrganize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbdFindMovie;
        private System.Windows.Forms.FolderBrowserDialog fbdMovieOrgPath;
        private System.Windows.Forms.Label lblTopLevelPath;
        private System.Windows.Forms.Button btnSelectTopLevel;
        private System.Windows.Forms.CheckBox cbCreateFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewPath;
        private System.Windows.Forms.ProgressBar progBarOrgProgress;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

