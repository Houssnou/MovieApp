﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MovieApp.Models;
using MovieApp.ViewModels;
using static MovieApp.Models.CacheData;

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

    public ActionResult New()
    {
        var membershipTypes = _context.MembershipTypes.ToList();

        var viewModel = new CustomerFormViewModel
        {
            Customer = new Customer(),
            MembershipTypes = membershipTypes
        };

        return View("CustomerForm",viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        //if customer has an id its an update operation else it a creation
        if (customer.Id == 0)
            _context.Customers.Add(customer);
        else
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

           // TryUpdateModel(customerInDb);
           //using automapper mapper.map(customer, customerInDb)

           customerInDb.Name = customer.Name;
           customerInDb.Dob = customer.Dob;
           customerInDb.MembershipTypeId = customer.MembershipTypeId;
           customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Customers");
    }
    
    public ViewResult Index()
    {
        //adding data caching
        if (MemoryCache.Default[CachedGenres] == null)
        {
            MemoryCache.Default[CacheData.CachedGenres] = _context.Genres.ToList();
        }

        var genres = MemoryCache.Default[CacheData.CachedGenres] as IEnumerable<Genre>;

        return View();
    }

    public ActionResult Details(int id)
    {
        var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return new HttpNotFoundResult();

        return View(customer);
    }

    public ActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer == null)
            return HttpNotFound();

        var viewModel = new CustomerFormViewModel
        {
            Customer = customer,
            MembershipTypes = _context.MembershipTypes.ToList()
        };
        return View("CustomerForm", viewModel);
    }
    }
}