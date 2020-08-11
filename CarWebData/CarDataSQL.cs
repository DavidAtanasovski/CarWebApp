using CarWebCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarWebData
{
    public class CarDataSQL : ICarData
    {
        private readonly CarWebDbContext CarWebDbContext;
        public CarDataSQL(CarWebDbContext CarWebDbContext)
        {
            this.CarWebDbContext = CarWebDbContext;
        }
        public int Commit()
        {
            return CarWebDbContext.SaveChanges();
        }

        public Car Create(Car car)
        {
            CarWebDbContext.Cars.Add(car);
            return car;
        }

        public Car Delete(int carId)
        {
            var tempCar = CarWebDbContext.Cars.SingleOrDefault(r => r.Id == carId);
            if (tempCar != null)
            {
                CarWebDbContext.Cars.Remove(tempCar);
            }
            return tempCar;
        }

        public Car GetCarById(int carId)
        {
            return CarWebDbContext.Cars.SingleOrDefault(r => r.Id == carId);
        }

        public IEnumerable<Car> GetCars(string name = null)
        {
            var param = !string.IsNullOrEmpty(name) ? $"{name}%" : name;
            return CarWebDbContext.Cars.Where(r => string.IsNullOrEmpty(name) || EF.Functions.Like(r.ModelName, param)).ToList();
        }
    }
}
