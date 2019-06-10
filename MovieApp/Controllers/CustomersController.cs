using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class CustomersController:Controller

    {
    private ApplicationDbContext _context;

    public CustomersController()
    {
        _context = new ApplicationDbContext();
    }

    //protected override void Dispose(bool disposing)
    //{
    //    _context.Dispose();
    //}

    public ViewResult Index()
    {
        var customers = _context.Customers.Include(c => c.MembershipType).ToList();

        return View(customers);
    }

    public ActionResult Details(int id)
    {
        var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return new HttpNotFoundResult();

        return View(customer);
    }
    }
}