using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class UserDTO
    {
        public int User_Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime? Bday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
