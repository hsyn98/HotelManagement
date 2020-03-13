using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Services
    {
        public int Id { get; set; }
        [Required]
        public ServicesGroups ServiceGroup { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool ServiceStatus { get; set; }
        public string PhotoPath { get; set; }
    }
}
