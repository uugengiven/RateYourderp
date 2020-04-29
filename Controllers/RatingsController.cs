using System;
using Microsoft.AspNetCore.Mvc;
using RateYourDerp.Models;
using System.Linq;

namespace RateYourDerp.Controllers
{
    public class RatingsController : Controller
    {
        private DerpDb db; // _context

        public RatingsController(DerpDb globalDb) // DerpDb context
        {
            db = globalDb;
            // _context = contex;
        }

        // Page that shows all pictures/ratings
        public IActionResult Show()
        {
            return View(db.Derps.OrderByDescending(d => d.Id).ToList());
        }

        // Add a picture and rating page
        public IActionResult Add()
        {
            return View();
        }

        // Save from Add page
        public IActionResult Save(string Title, string Image, int Rating)
        {
            Derp newderp = new Derp();
            newderp.Title = Title;
            newderp.Image = Image;
            newderp.Rating = Rating;

            db.Derps.Add(newderp);
            db.SaveChanges();
            return Redirect("/");
        }
    }
}