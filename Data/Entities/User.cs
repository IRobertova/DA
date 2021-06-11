using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User:BaseEntity
    {
        [Required, StringLength(30)]
        public string FName { get; set; }

        [Required, StringLength(30)]
        public string LName { get; set; }
        public DateTime?  Bday { get; set; }

        [Required, StringLength(10)]
        public string Phone { get; set; }

        [StringLength(60)]
        public string Address { get; set; }
        public virtual ICollection<User_Movie> UserMovies { get; set; }


    }
}
