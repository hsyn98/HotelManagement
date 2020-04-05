using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class RoomBookViewModel : UserEditViewModel
    {
        public int SelectedBranchId { get; set; }
        public int SelectedRoomId { get; set; }
        public int RoomStar { get; set; }

        public IEnumerable<User> ExistUsers { get; set; }

        [Required(ErrorMessage = "Please Select Starting Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please Select Finishing Date")]
        public DateTime FinishDate { get; set; }

        public int NumberoOfDays { get; set; }

        public float Price { get; set; }
    }
}
