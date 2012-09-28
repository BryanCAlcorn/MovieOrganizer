using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MovieOrganizer
{
    public class IMDBTextDAL : IMovieDAL
    {
        private const string textFilePath = @"C:\Documents and Settings\O540606\Desktop\genres.txt";
        private string allGenres;

        public IMDBTextDAL()
        {
            readFile();
        }

        private void readFile()
        {
            if (File.Exists(textFilePath) && String.IsNullOrEmpty(allGenres))
            {
                StreamReader sr = null;
                try
                {
                    sr = File.OpenText(textFilePath);
                    allGenres = sr.ReadToEnd();
                }
                catch (Exception)
                {
                    throw new Exception("Error reading genre file");
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
                
            }
        }

        public List<string> getGenres(string title)
        {
            List<string> genres = new List<string>();
            Regex regexTitle = new Regex("\\b" + title + "\\b");
            if (!String.IsNullOrEmpty(allGenres) && regexTitle.IsMatch(allGenres))
            {
                MatchCollection allMatches = regexTitle.Matches(allGenres);
                foreach (Match match in allMatches)
                {
                    int index = match.Index;
                    int eol = allGenres.IndexOf("\n", index);
                    string line = allGenres.Substring(index, eol - index);
                    int endOfSpaces = line.LastIndexOf('\t') + 1;
                    string genre = line.Substring(endOfSpaces, line.Length - endOfSpaces);
                    
                    if (!genres.Contains(genre))
                    {
                        genres.Add(genre);
                    }
                }
            }

            return genres;
        }
    }
}
