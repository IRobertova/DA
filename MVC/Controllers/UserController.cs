using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string Search="")
        {
            List<UserVM> usersVM = new List<UserVM>();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                if (!String.IsNullOrEmpty(Search))
                {
                    foreach (var item in service.GetUsers(Search))
                    {
                        usersVM.Add(new UserVM(item));

                    }
                    return View(usersVM);

                }
                else
                {
                    foreach (var item in service.GetUsers(Search))
                    {
                        usersVM.Add(new UserVM(item));
                    }
                    return View(usersVM);

                }
            }

        }

        public ActionResult Details(int id)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userDto = service.GetUserByID(id);
                userVM = new UserVM(userDto);
            }

            return View(userVM);
        }

        public ActionResult Create()
        {
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserDTO userDTO = new UserDTO
                        {
                            FName=userVM.FName,
                            LName=userVM.LName,
                            Bday=userVM.Bday,
                            Address=userVM.Address,
                            Phone=userVM.Phone
                        };
                        service.PostUser(userDTO);
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
            catch
            {
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userDto = service.GetUserByID(id);
                userVM = new UserVM(userDto);
            }
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserDTO userDto = new UserDTO
                        {
                            User_Id=userVM.User_Id,
                            FName = userVM.FName,
                            LName = userVM.LName,
                            Bday = userVM.Bday,
                            Address = userVM.Address,
                            Phone = userVM.Phone

                        };
                        service.PostUser(userDto);
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
            catch
            {
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserDataList();
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }

    }
}