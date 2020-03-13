using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class BranchDetailsViewModel
    {
        public Branch Branch { get; set; }
        public IEnumerable<Room> Room { get; set; }
    }
}
