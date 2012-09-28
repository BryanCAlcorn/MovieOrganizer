using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieOrganizer
{
    interface IMovieDAL
    {
        List<string> getGenres(string title);
    }
}
