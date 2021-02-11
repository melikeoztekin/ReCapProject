using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Descriptions.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Sisteme " + car.Id + " numaralı " +car.Descriptions +" model araç bilgisi eklendi.");
            }
            else if (car.Descriptions.Length < 2)
            {
                Console.WriteLine("Araç model açıklaması en az 2 karakter olmalıdır. ");
            }
            else if (car.DailyPrice == 0)
            {
                Console.WriteLine("Araç günlük kira fiyatı 0'dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Sistemden " + car.Id + " numaralı " + car.Descriptions + " model araç bilgisi silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Sistemde yer alan " + car.Id + " numaralı " + car.Descriptions + " model araç bilgisi güncellendi.");
        }
    }
}
