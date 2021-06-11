using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User_Movie : BaseEntity
    {
        public int Movie_Id { get; set; }
        public virtual Movie Movie { get; set; }

        public int User_Id { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateTime Rent_Day { get; set; }
        public DateTime Return_Day { get; set; }
        public decimal Price { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }



   



    }
}
