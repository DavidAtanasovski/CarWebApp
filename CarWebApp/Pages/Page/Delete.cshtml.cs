using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebCore;
using CarWebData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWebApp.Pages.Page
{
    public class DeleteModel : PageModel
    {
        private readonly ICarData carData;
        public Car Car { get; set; }

        public DeleteModel (ICarData carData)
        {
            this.carData = carData;
        }

        public IActionResult  OnGet(int carId)
        {
            Car = carData.GetCarById(carId);
            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int carId)
        {
            var temp = carData.Delete(carId);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }

            carData.Commit();
            TempData["TempMessage"] = "The car was deleted.";
            return RedirectToPage("./CarModels");
        }
    }
}