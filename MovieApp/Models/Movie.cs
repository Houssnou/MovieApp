using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [Display (Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }

    }
}