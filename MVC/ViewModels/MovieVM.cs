using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class MovieVM
    {
        public int Movie_Id { get; set; }

        [Required, StringLength(180)]
        public string Title { get; set; }
        public int Year { get; set; }

        [Required, StringLength(40)]
        public string Genre { get; set; }
        public int Duration { get; set; }

        [StringLength(400)]
        public string Resume { get; set; }

        [Required]
        public decimal Price { get; set; }



        public MovieVM() { }

        public MovieVM(MovieDTO movieDTO)
        {
            Movie_Id = movieDTO.Movie_Id;
            Title = movieDTO.Title;
            Year = movieDTO.Year;
            Genre = movieDTO.Genre;
            Duration = movieDTO.Duration;
            Resume = movieDTO.Resume;
            Price = movieDTO.Price;
        }
    }
}