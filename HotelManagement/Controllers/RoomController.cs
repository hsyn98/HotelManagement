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
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public RoomController(IBranchRepository branchRepository,
                              IRoomRepository roomRepository,
                              IUserRepository userRepository,
                              IBookRepository bookRepository)
        {
            _branchRepository = branchRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
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
        public IActionResult Book(int id, string search = null)
        {   
            var foundUsers = _userRepository.Search(null);
            if (!string.IsNullOrEmpty(search))
            {
                foundUsers = _userRepository.Search(search);
            }

            Room room = _roomRepository.GetRoom(id);
            Branch branch = _branchRepository.GetBranch(room.BranchId);

            RoomBookViewModel roomBookViewModel = new RoomBookViewModel()
            {
                SelectedBranchId = branch.Id,
                SelectedRoomId = room.Id,
                RoomStar = room.Star,
                ExistUsers = foundUsers
            };

            return View(roomBookViewModel);
        }

        [HttpPost]
        public IActionResult Book(RoomBookViewModel roomOrder)
        {
            //if (ModelState.IsValid)
            //{

            //}
            //else
            //{
            //    return RedirectToAction("book", "room", new { });
            //}

            User newUser = new User
            {
                Name = roomOrder.Name,
                Surname = roomOrder.Surname,
                Email = roomOrder.Email,
                CreatedDate = DateTime.Now,
                Gender = roomOrder.Gender,
                Status = roomOrder.Status
            };

            _userRepository.Add(newUser);
            int lastUserId = _userRepository.AddedUserId();

            Book newBook = new Book
            {
                RoomId = roomOrder.SelectedRoomId,
                UserId = lastUserId,
                StartDate = roomOrder.StartDate,
                FinishDate = roomOrder.FinishDate,
                NumberoOfDays = roomOrder.FinishDate.Day - roomOrder.StartDate.Day,
                Price = roomOrder.RoomStar * 10 * (roomOrder.StartDate.Day - roomOrder.FinishDate.Day)
            };

            _bookRepository.Add(newBook);

            Room roomState = _roomRepository.GetRoom(roomOrder.SelectedRoomId);
            roomState.RoomStatus = RoomStatus.Captured;

            _roomRepository.Update(roomState);

            return RedirectToAction("details", "branch", new { id = roomOrder.SelectedBranchId });

        }

        //public IActionResult AddBook (RoomBookViewModel roomOrder, int userId)
        //{
            

        //    return RedirectToAction("details", "branch", new { id = roomOrder.Room.BranchId });
        //}
    }
}
