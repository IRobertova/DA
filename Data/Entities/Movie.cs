using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Movie :BaseEntity
    {
        [Required,StringLength(180)]
        public string Title { get; set; }

        public virtual ICollection<User_Movie> UserMovies { get; set; }

        public int Year { get; set; }

        [Required, StringLength(40)]
        public string Genre { get; set; }
        public int Duration { get; set; }
        [StringLength(400)]
        public string Resume { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
