using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=123, ColorId=124554, ModelYear=2019, DailyPrice=650, Descriptions="BMW M2 COMPETITION"},
                new Car{Id=2, BrandId=234, ColorId=172355, ModelYear=2016, DailyPrice=500, Descriptions="AUDI A3 SEDAN"},
                new Car{Id=3, BrandId=345, ColorId=542367, ModelYear=2017, DailyPrice=1000, Descriptions="ALFA ROMEO GİULİETTA"},
                new Car{Id=4, BrandId=123, ColorId=127535, ModelYear=2016, DailyPrice=750, Descriptions="BMW M4 SPECIFICATIONS"},
                new Car{Id=5, BrandId=234, ColorId=254962, ModelYear=2020, DailyPrice=900, Descriptions="AUDI S4"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(Car => Car.Id == Car.Id);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(Car => Car.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(Car => Car.Id == car.Id);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Descriptions = car.Descriptions;
        }
    }
}
