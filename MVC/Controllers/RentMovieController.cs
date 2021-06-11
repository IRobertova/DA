using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RentMovieController : Controller
    {
        // GET: RentMovie
        public ActionResult Index(string SearchUM="")
        {
            List<UserMovieVM> userMoviesVMs = new List<UserMovieVM>();
            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetUserMovies(SearchUM))
                {
                    userMoviesVMs.Add(new UserMovieVM(item));
                }
            }
            return View(userMoviesVMs);
        }


        public ActionResult Details(int id)
        {
            UserMovieVM userMovieVM = new UserMovieVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userMovieDto = service.GetUserMovieById(id);
                userMovieVM = new UserMovieVM(userMovieDto);
            }
            return View(userMovieVM);
        }

        public ActionResult Create()
        {
            ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserMovieVM userMovieVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    UserMovieDTO userMovieDTO = new UserMovieDTO
                    {

                        Rent_Day = userMovieVM.Rent_Day,
                        Return_Day = userMovieVM.Return_Day,
                        Comment = userMovieVM.Comment,
                        Price = userMovieVM.Price,
                        Movie_Id=userMovieVM.Movie_Id,
                        Movie = new MovieDTO
                        {
                            Movie_Id = userMovieVM.Movie_Id,
                        },
                        User_Id=userMovieVM.User_Id,
                        User = new UserDTO
                        {
                            User_Id=userMovieVM.User_Id,
                        }
                    };
                    service.PostUserMovie(userMovieDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();

                return View();
            }
            
        }

        public ActionResult Edit(int id)
        {
            UserMovieVM userMovieVM = new UserMovieVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userMovieDto = service.GetUserMovieById(id);
                userMovieVM = new UserMovieVM(userMovieDto);
            }
            ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
            return View(userMovieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserMovieVM userMovieVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserMovieDTO userMovieDTO = new UserMovieDTO
                        {
                            UserMovie_Id=userMovieVM.UserMovie_Id,
                            Rent_Day = userMovieVM.Rent_Day,
                            Return_Day = userMovieVM.Return_Day,
                            Comment = userMovieVM.Comment,
                            Price = userMovieVM.Price,
                            Movie_Id = userMovieVM.Movie_Id,
                            Movie = new MovieDTO
                            {
                                Movie_Id = userMovieVM.Movie_Id,
                            },
                            User_Id = userMovieVM.User_Id,
                            User = new UserDTO
                            {
                                User_Id = userMovieVM.User_Id,
                            }

                        };
                        service.PutUserMovie(userMovieDTO);
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
            catch
            {
                ViewBag.Movies = Helpers.LoadDataUtilities.LoadMovieDataList();
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUserMovie(id);
            }
            return RedirectToAction("Index");
        }

    }
}