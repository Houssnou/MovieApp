using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using MovieApp.Dtos;
using MovieApp.Models;

namespace MovieApp.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("Invalid movie IDs!");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer ID");

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
