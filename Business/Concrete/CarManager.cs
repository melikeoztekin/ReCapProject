using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int carId)
        {
            try
            {
                var carBul = _carDal.Get(c => c.CarId == carId);
                if (carBul != null)
                {
                    _carDal.Delete(carBul);
                    return new SuccessResult(Messages.CarDeleted);
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<CarDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.CarDto(c=>c.BrandId== brandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.CarDto(c => c.ColorId == colorId));
        }
        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<CarDto>> GetCarDto()
        {
            var result = _carDal.CarDto();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDto>>("Araç bulunamadı.");
            }
            return new SuccessDataResult<List<CarDto>>(result, Messages.CarListed);
        }

        [TransactionScopeAspect]
        public Result AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IDataResult<List<CarDto>> GetCarDtoCarId(int CarId)
        {
            var result = _carDal.CarDto(c=>c.CarId==CarId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDto>>("Araç bulunamadı.");
            }
            return new SuccessDataResult<List<CarDto>>(result, Messages.CarListed);
        }

        public IDataResult<List<CarDto>> GetCarDetailBrandAndColorId(int brandId, int colorId)
        {
            var result = _carDal.CarDto(c => c.BrandId == brandId && c.ColorId==colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDto>>("Araç bulunamadı.");
            }
            return new SuccessDataResult<List<CarDto>>(result, Messages.CarListed);
        }
    }
}
