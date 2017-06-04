using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASP_Sample.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> movies;
        public SelectList genres;
        public string movieGenre { get; set; }
    }
}
