using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBranchRepository _branchRepository;

        public HomeController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public IActionResult Index()
        {
            var model = _branchRepository.GetAllBranches();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}