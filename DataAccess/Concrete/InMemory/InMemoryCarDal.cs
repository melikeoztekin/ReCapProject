using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=123, ColorId=124554, ModelYear=2019, DailyPrice=650, Description="BMW M2 COMPETITION"},
                new Car{CarId=2, BrandId=234, ColorId=172355, ModelYear=2016, DailyPrice=500, Description="AUDI A3 SEDAN"},
                new Car{CarId=3, BrandId=345, ColorId=542367, ModelYear=2017, DailyPrice=1000, Description="ALFA ROMEO GİULİETTA"},
                new Car{CarId=4, BrandId=123, ColorId=127535, ModelYear=2016, DailyPrice=750, Description="BMW M4 SPECIFICATIONS"},
                new Car{CarId=5, BrandId=234, ColorId=254962, ModelYear=2020, DailyPrice=900, Description="AUDI S4"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(Car => Car.CarId == Car.CarId);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(Car => Car.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(Car => Car.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}
