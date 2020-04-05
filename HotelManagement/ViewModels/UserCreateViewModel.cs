using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class UserCreateViewModel : RoomEditViewModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public new string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        [Required]
        public UserStatus Status { get; set; }
    }
}
