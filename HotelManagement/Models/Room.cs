using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")] 
        public Branch Branch { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; }

        [Required]
        public int Star { get; set; }
    }
}
