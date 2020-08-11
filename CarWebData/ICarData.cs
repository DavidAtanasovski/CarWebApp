using CarWebCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWebData
{
    public interface ICarData
    {
        Car GetCarById(int carId);
        Car Create(Car car);
        int Commit();
        Car Delete(int carId);

        IEnumerable<Car> GetCars(string name = null);
    }
}
