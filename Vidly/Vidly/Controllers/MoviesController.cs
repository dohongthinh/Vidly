using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //Section 2 work starts from here
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies {Id =1, Name ="Shrek"},
                new Movies {Id =2, Name ="Wall-e"}
            };
        }

        //Section 2 knowledge starts from here
        //In order to have the works work, put Index method into comments
        // GET: Movie/Random
        public ActionResult Random() //ActionResult helps to return various action results
        {
            var movie = new Movies() { Name = "Bumblebee!" };
            //add 2 customer objects
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer {Name  ="Customer 2"}
            };
            //initialize movie properties
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel); // this is also the best way to pass datas to view
            //return Content("Hello World!"); //return HttpNotFound(); //return new EmptyResult(); //return new ViewResult();
            // return RedirectToAction(name of action, controller, pass argument to target action);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        // ? is for unnullable
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //apply route to MapMVCattributeroute() -> help handle routes easier
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]//regex is not a string -> \\ 
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}