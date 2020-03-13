using HotelManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModels
{
    public class BranchCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Cities City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        //[Display(Name = "Phone")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public BranchStatus BranchStatus { get; set; }
        public IFormFile Photo { get; set; }
    }
}