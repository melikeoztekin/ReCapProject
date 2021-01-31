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
        public List<Car> GetAll()
        {
            return _car.GetAll();
        }

    }
}
