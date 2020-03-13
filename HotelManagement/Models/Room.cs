using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public RoomStatus RoomStatus { get; set; }
        [Required]
        public int Star { get; set; }
    }
}
