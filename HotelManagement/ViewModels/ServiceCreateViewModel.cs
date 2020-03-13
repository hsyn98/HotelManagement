using HotelManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class ServiceCreateViewModel
    {
        [Required]
        public ServicesGroups ServiceGroup { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool ServiceStatus { get; set; }
        public IFormFile Photo { get; set; }
    }
}
