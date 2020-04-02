using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public BranchController(IBranchRepository branchRepository,
                                IRoomRepository roomRepository,
                                IHostingEnvironment hostingEnvironment)
        {
            _branchRepository = branchRepository;
            _roomRepository = roomRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BranchCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Branch newBranch = new Branch
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    BranchStatus = model.BranchStatus,
                    PhotoPath = uniqueFileName
                };

                _branchRepository.Add(newBranch);
                return RedirectToAction("index", "home");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Branch branch = _branchRepository.GetBranch(id);
            BranchEditViewModel branchEditViewModel = new BranchEditViewModel
            {
                Id = branch.Id,
                Name = branch.Name,
                City = branch.City,
                Address = branch.Address,
                PhoneNumber = branch.PhoneNumber,
                ExistingPhotoPath = branch.PhotoPath,
                BranchStatus = branch.BranchStatus
            };

            return View(branchEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BranchEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Branch branch = _branchRepository.GetBranch(model.Id);
                branch.Name = model.Name;
                branch.City = model.City;
                branch.Address = model.Address;
                branch.PhoneNumber = model.PhoneNumber;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    branch.PhotoPath = ProcessUploadedFile(model);
                }
                branch.BranchStatus = model.BranchStatus;

                _branchRepository.Update(branch);
                return RedirectToAction("index", "home");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            _branchRepository.Delete(id);
            return RedirectToAction("index", "home");
        }

        public IActionResult Details(int id)
        {
            Branch branch = _branchRepository.GetBranch(id);
            var roomModel = _roomRepository.GetAllRooms(id);

            BranchDetailsViewModel branchDetailsViewModel = new BranchDetailsViewModel()
            {
                Branch = branch,
                Room = roomModel
            };

            return View(branchDetailsViewModel);
        }

        private string ProcessUploadedFile(BranchCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}