using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}