using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebApp.Models;
using CarWebCore;
using CarWebData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApp.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarApiController : ControllerBase
    {
        private readonly ICarData carData;
        public CarApiController (ICarData carData)
        {
            this.carData = carData;
        }

        [HttpGet]
        public IActionResult GetCarsAll()
        {
            var data = carData.GetCars();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var data = carData.GetCarById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(CarDto carCreateDto)
        {
            if(carCreateDto == null )
            {
                return BadRequest();
            }
            var car = new Car();
            car.EngineLabel = carCreateDto.EngineLabel;
            car.FuelType = carCreateDto.FuelType;
            car.HeaviestCurbWeight = car.HeaviestCurbWeight;
            car.LightestCurbWeight = car.LightestCurbWeight;
            car.MaxEngPower = car.MaxEngPower;
            car.MaxTorqPower = car.MaxTorqPower;
            car.ModelName = car.ModelName;
            car.OverallHeight = car.OverallHeight;
            car.OverallLenght = car.OverallLenght;
            car.OverallWidth = car.OverallWidth;
            car.Photo = car.Photo;
            car.ProductLabel = car.ProductLabel;
            car.Seats = car.Seats;
            car.Tires = car.Tires;
            car.Wheels = car.Wheels;


            carData.Create(car);
            carData.Commit();
            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = carData.Delete(id);
            if (temp == null)
            {
                return BadRequest();
            }
            carData.Commit();
            return NoContent();
        }
    }
}
