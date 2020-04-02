using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomController(IBranchRepository branchRepository,
                              IRoomRepository roomRepository)
        {
            _branchRepository = branchRepository;
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ViewResult Create(int id)
        {
            Branch branch = _branchRepository.GetBranch(id);
            RoomCreateViewModel roomCreateViewModel = new RoomCreateViewModel
            {
                BranchId = branch.Id,
                Name = branch.Name
            };

            return View(roomCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(RoomCreateViewModel model)
        {
            for (int i = 10; i < (model.Floor + 1) * 10; i++)
            {
                Room newRoom = new Room
                {
                    BranchId = model.BranchId,
                    Floor = i / 10,
                    RoomNumber = i,
                    RoomStatus = RoomStatus.Free,
                    Star = model.Star
                };

                _roomRepository.Add(newRoom);
            }

            return RedirectToAction("details", "branch", new { id = model.BranchId });
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            return RedirectToAction("details", "branch");
        }

        [HttpPost]
        public IActionResult Book(RoomBookViewModel roomorder)
        {
            return RedirectToAction("details", "branch");
        }
    }
}
