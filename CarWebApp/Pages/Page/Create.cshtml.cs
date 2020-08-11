using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarWebCore;
using CarWebData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWebApp.Pages.Page
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly ICarData carData;
        
        [BindProperty]
        public Car Car { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public CreateModel(ICarData carData, IWebHostEnvironment hostEnvironment)
        {
            this.carData = carData;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet(int? carId)
        {
            if (carId.HasValue)
            {
                Car = carData.GetCarById(carId.Value);
                if (Car == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Car = new Car();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Car.Id == 0 && Photo != null)
                {
                    Car.Photo = ProcessUploadedFile();

                    Car = carData.Create(Car);
                    TempData["Message"] = "The Car is creagted.";
                }
                carData.Commit();
                return RedirectToPage("./CarModels", new { carId = Car.Id });
            }
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
    }
}