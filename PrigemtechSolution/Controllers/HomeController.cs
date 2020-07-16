using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrigemtechSolution.Models;
using PrigemtechSolution.ViewModels;

namespace PrigemtechSolution.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        [HttpGet]
        //[Authorize]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        //[Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                uniqueFileName = ProcessUploadedFile(model, uniqueFileName);
                //if (model.Photo != null)
                //{

                //    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //}
                //if (model.Photos != null && model.Photos.Count > 0)
                //{
                //    foreach (IFormFile photo in model.Photos)
                //    {


                //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //    }
                //}
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Deparment = model.Deparment,
                    PhotoPath = uniqueFileName
                };
                    
                    
                    
                    _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }



            return View();
        }


        [HttpGet]
        //[Authorize]
        public IActionResult Edit(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Deparment = employee.Deparment,
                ExisitingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        //[Authorize]
        public IActionResult Edit(EmployeeEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Deparment = model.Deparment;
                string uniqueFileName = null;
                uniqueFileName = ProcessUploadedFile(model, uniqueFileName);
                if (model.Photo != null)
                {
                    if(model.ExisitingPhotoPath != null)
                    {
                      string filePath =  Path.Combine(webHostEnvironment.WebRootPath, "images", model.ExisitingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model, uniqueFileName);
                }
                //employee.PhotoPath = uniqueFileName;
                
             
                //if (model.Photos != null && model.Photos.Count > 0)
                //{
                //    foreach (IFormFile photo in model.Photos)
                //    {


                //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //    }
                //}
              



                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            };
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model, string uniqueFileName)
        {
            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                    model.Photo.CopyTo(fileStream);
                } ;
               
            }

            return uniqueFileName;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;

                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            //_employeeRepository.GetEmployee(2);
            return View(homeDetailsViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
