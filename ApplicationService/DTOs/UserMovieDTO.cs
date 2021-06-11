using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class UserMovieDTO
    {
        public int UserMovie_Id { get; set; }
        public int Movie_Id { get; set; }
        public virtual MovieDTO Movie { get; set; }

        public int User_Id { get; set; }
        public virtual UserDTO User { get; set; }

        public DateTime Rent_Day { get; set; }
        public DateTime Return_Day { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }

    }
}
