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
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ServiceController(IServiceRepository serviceRepository,
                                 IHostingEnvironment hostingEnvironment)
        {
            _serviceRepository = serviceRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _serviceRepository.GetAllServices();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Services newService = new Services
                {
                    ServiceGroup = model.ServiceGroup,
                    Name = model.Name,
                    ServiceStatus = model.ServiceStatus,
                    PhotoPath = uniqueFileName
                };

                _serviceRepository.Add(newService);
                return RedirectToAction("index", "service");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Services service = _serviceRepository.GetService(id);
            ServiceEditViewModel serviceEditViewModel = new ServiceEditViewModel
            {
                Id = service.Id,
                ServiceGroup = service.ServiceGroup,
                Name = service.Name,
                ServiceStatus = service.ServiceStatus,
                ExistingPhotoPath = service.PhotoPath,
            };

            return View(serviceEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ServiceEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Services service = _serviceRepository.GetService(model.Id);
                service.ServiceGroup = model.ServiceGroup;
                service.Name = model.Name;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    service.PhotoPath = ProcessUploadedFile(model);
                }
                service.ServiceStatus = model.ServiceStatus;

                _serviceRepository.Update(service);
                return RedirectToAction("index", "service");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            _serviceRepository.Delete(id);
            return RedirectToAction("index", "service");
        }

        private string ProcessUploadedFile(ServiceCreateViewModel model)
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