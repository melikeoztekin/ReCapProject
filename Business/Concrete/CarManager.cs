using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        public IResult Add(Car car)
        {
            if (car.Descriptions.Length > 2 && car.DailyPrice != 0)
            {
                _carDal.Add(car);
                Console.WriteLine(car.Id + " numaralı " + car.Descriptions + " model araç bilgisi sisteme eklendi.");
                return new SuccessResult(Messages.Added);
            }
            else if (car.DailyPrice == 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else if (car.Descriptions.Length < 2)
            {
                return new ErrorResult(Messages.DescriptionInvalid);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }
        public IResult Delete(int carId)
        {
            try
            {
                var carBul = _carDal.Get(c => c.Id == carId);
                if (carBul != null)
                {
                    _carDal.Delete(carBul);
                    return new SuccessResult(Messages.Deleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }           
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarsListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public List<Car> GetCarsByCarId(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Sistemde yer alan " + car.Id + " numaralı " + car.Descriptions + " model araç bilgisi güncellendi.");
            return new Result(true, Messages.Updated);
        }
    }
}
