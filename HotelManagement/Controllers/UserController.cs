using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var model = _userRepository.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    CreatedDate = DateTime.Now,
                    Gender = model.Gender,
                    Status = model.Status
                };

                _userRepository.Add(newUser);
                return RedirectToAction("index", "user");
            }

            return View();
        }

        public IActionResult Activate (UserEditViewModel model)
        {
            User user = _userRepository.GetUser(model.UserId);
            user.Status = UserStatus.Active;

            _userRepository.Update(user);
            return RedirectToAction("index", "user");
        }

        public IActionResult Deactivate(UserEditViewModel model)
        {
            User user = _userRepository.GetUser(model.UserId);
            user.Status = UserStatus.DeActive;

            _userRepository.Update(user);
            return RedirectToAction("index", "user");
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(UserLoginViewModel loginModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userModel = _userRepository.GetUser(loginModel.Email);

        //        foreach(var model in userModel)
        //        {
        //            if (model.Password == loginModel.Password)
        //            {
        //                return RedirectToAction("index", "home");
        //            }
        //        }

        //    }
        //    return View(loginModel);
        //}
    }
}
