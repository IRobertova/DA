using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadMovieDataList()
        {
            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetMovies(""), "Movie_Id", "Title");

            }
        }
        public static SelectList LoadUserDataList()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetUsers(""), "User_Id",  "Fname");

            }
        }

    }
}