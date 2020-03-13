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
                    FloorNumber = i,
                    RoomStatus = RoomStatus.Free,
                    Star = model.Star
                };

                _roomRepository.Add(newRoom);
            }
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Order(int id)
        {
            Room room = _roomRepository.GetRoom(id);
            RoomOrderViewModel roomOrderViewModel = new RoomOrderViewModel
            {
                Id = room.Id,
                BranchId = room.BranchId,
                Floor = room.Floor,
                FloorNumber = room.FloorNumber,
                RoomStatus = room.RoomStatus,
                Star = room.Star
            };

            return View(roomOrderViewModel);
        }

        [HttpPost]
        public IActionResult Order(RoomOrderViewModel roomorder)
        {
            return RedirectToAction("details", "branch");
        }
    }
}
