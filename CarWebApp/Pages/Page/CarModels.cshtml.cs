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
    public class CarModelsModel : PageModel
    {
       
        private readonly ICarData carData;

        public IEnumerable<Car> Cars { get; set; }

        public CarModelsModel(ICarData carData)
        {
            this.carData = carData;
        }

        public void OnGet()
        {
            Cars = carData.GetCars();
        }
        
    }
    
}