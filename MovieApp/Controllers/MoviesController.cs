using System.Collections.Generic;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Matrix"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
                new Customer {Name = "Customer 3"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

           return View(viewModel);
           //return Content("The best movie ever!!!");
           //return RedirectToAction("Index", "Home", new);

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}