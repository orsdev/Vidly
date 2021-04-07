using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public Movies Movies { get; set; }
        public IEnumerable<Genres> Genres { get; set; }

        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                    return "Edit Movie";
                else
                    return "Add Movie";
            }
        }
    }
}