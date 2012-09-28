using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace MovieOrganizer
{
    public class Movie
    {
        public string title { get; set; }
        public List<string> genres { get; set; }
        public FileInfo file { get; set; }
    }
}
