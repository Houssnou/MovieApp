using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //public Movie Movie { get; set; }
        //matching prop by prop to be able to populate the viewModel with default values
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Qte in stock")]
        [Range(1, 99)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Formtitle
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        

        //default const to set movie.id to 0 for new movie
        public MovieFormViewModel()
        {
            Id = 0;
        }

        //constructor to map movie info to the MovieForm field
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}