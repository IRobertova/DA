using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class UserMovieVM
    {
        public int UserMovie_Id { get; set; }
        public int Movie_Id { get; set; }
        public MovieVM MovieVM { get; set; }

        public int User_Id { get; set; }
        public UserVM UserVM { get; set; }

        [Required]
        [Display(Name = "Rent date")]
        [DataType(DataType.Date)]
        public DateTime Rent_Day { get; set; }


        [Display(Name = "Return date")]
        [DataType(DataType.Date)]
        public DateTime Return_Day { get; set; }

        public decimal Price { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }



        public UserMovieVM() { }

        public UserMovieVM(UserMovieDTO userMovieDTO)
        {
            UserMovie_Id = userMovieDTO.UserMovie_Id;
            Movie_Id = userMovieDTO.Movie_Id;
            User_Id = userMovieDTO.User_Id;
            Rent_Day = userMovieDTO.Rent_Day;
            Return_Day = userMovieDTO.Return_Day;
            Price = userMovieDTO.Price;
            Comment = userMovieDTO.Comment;
            Movie_Id = userMovieDTO.Movie_Id;
            /*MovieVM = new MovieVM
            {
                Movie_Id = userMovieDTO.Movie_Id,
                Title = userMovieDTO.Movie.Title
            };*/
            User_Id = userMovieDTO.User_Id;
            /*UserVM = new UserVM
            {
                User_Id = userMovieDTO.User_Id,
                FName = userMovieDTO.User.FName,
                //LName = userMovieDTO.User.LName
            };*/
        }


    }
}