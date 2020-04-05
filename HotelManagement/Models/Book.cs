using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required(ErrorMessage = "Please Select Starting Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please Select Finishing Date")]
        public DateTime FinishDate { get; set; }

        public int NumberoOfDays { get; set; }

        public float Price { get; set; }

    }
}
