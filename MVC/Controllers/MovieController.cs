using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index(string SearchM="")
        {
            List<MovieVM> moviesVM = new List<MovieVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetMovies(SearchM))
                {
                    moviesVM.Add(new MovieVM(item));
                }
            }

                return View(moviesVM);
        }

        public ActionResult Details(int id)
        {
            MovieVM movieVM = new MovieVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var movieDto = service.GetMovieByID(id);
                movieVM = new MovieVM(movieDto);
            }

            return View(movieVM);
        }
        public ActionResult Create()
        {
            ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieVM movieVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        MovieDTO movieDTO = new MovieDTO
                        {
                            Title = movieVM.Title,
                            Year = movieVM.Year,
                            Genre = movieVM.Genre,
                            Duration = movieVM.Duration,
                            Resume = movieVM.Resume,
                            Price = movieVM.Price
                        };
                        service.PostMovie(movieDTO);
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                return View();
            }
            catch
            {
                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            MovieVM movieVM = new MovieVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var movieDto = service.GetMovieByID(id);
                movieVM = new MovieVM(movieDto);
            }
            ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieVM movieVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        MovieDTO movieDto = new MovieDTO
                        {
                            Movie_Id=movieVM.Movie_Id,
                            Title = movieVM.Title,
                            Year = movieVM.Year,
                            Genre = movieVM.Genre,
                            Duration = movieVM.Duration,
                            Resume = movieVM.Resume,
                            Price = movieVM.Price
                            
                        };
                        service.PutMovie(movieDto);
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                return View();
            }
            catch
            {
                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteMovie(id);
            }
            return RedirectToAction("Index");
        }
    }
}