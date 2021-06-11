using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class UserVM
    {
        public int User_Id { get; set; }

        [Required, StringLength(30)]
        public string FName { get; set; }

        [Required, StringLength(30)]
        public string LName { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? Bday { get; set; }

        [Required, StringLength(10)]
        public string Phone { get; set; }

        [StringLength(60)]
        public string Address { get; set; }


        public UserVM() { }

        public UserVM(UserDTO userDTO)
        {
            User_Id = userDTO.User_Id;
            FName = userDTO.FName;
            LName = userDTO.LName;
            Bday = userDTO.Bday;
            Phone = userDTO.Phone;
            Address = userDTO.Address;
        }
    }
}