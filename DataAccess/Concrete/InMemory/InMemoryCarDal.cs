using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                new Car{CarId=1, BrandId=1, ColorId=1, CarName="BMW M2 CPMPETION", ModelYear=2019, DailyPrice=650, Description="Mat Siyah"},
                new Car{CarId=2, BrandId=2, ColorId=2, CarName="AUDI A3 SEDAN", ModelYear=2016, DailyPrice=500, Description="Otomatik Vites"},
                new Car{CarId=3, BrandId=3, ColorId=3, CarName="ALFA ROMEO GIULIETTA", ModelYear=2017, DailyPrice=1000, Description="Kış Lastikleri Mevcut"},
                new Car{CarId=4, BrandId=1, ColorId=4, CarName="BMW M4 SPECIFICATIONS", ModelYear=2016, DailyPrice=750, Description="Altın Sarısı- Otomatik Vites"},
                new Car{CarId=5, BrandId=2, ColorId=5, CarName="AUDI S4", ModelYear=2020, DailyPrice=900, Description="Otomatik Vites"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.CarName = car.CarName;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}
