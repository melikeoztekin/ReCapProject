using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _car;
        public CarManager(ICarDal car)
        {
            _car = car;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _car.Add(car);
            }
            else
            {
                Console.WriteLine("Fiyat bilgisi 0 olamaz.");
            }
        }

        public void Delete(Car car)
        {
            _car.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();
        }

        public void Update(Car car)
        {
            _car.Update(car);
        }
    }
}
