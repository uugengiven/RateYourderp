using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RateYourDerp.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Save(string Title, IFormFile Image, int Rating)
        {
            Derp newderp = new Derp();
            newderp.Title = Title;
            newderp.Image = Image.FileName;
            newderp.Rating = Rating;

            db.Derps.Add(newderp);
            db.SaveChanges(); // saves all of the database stuff

            // save image on harddrive too
            // open up a new file
            FileStream fs = new FileStream("wwwroot/images/" + Image.FileName, FileMode.OpenOrCreate);
            // dump in all of the image data
            Image.CopyTo(fs);
            // close/save file
            fs.Dispose();


            return Redirect("/");
        }
    }
}