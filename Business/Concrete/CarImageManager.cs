using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CarControl(carImage.CarId),CarImageCountControl(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = CarImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        private IDataResult<CarImage> CarImageControl(int carImageId)
        {
            var carImage = _carImageDal.Get(i=>i.CarImageId== carImageId);
            if (carImage!=null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            return new ErrorDataResult<CarImage>(Messages.CarNotFound);
        }

        private IDataResult<Car> CarControl(int carId)
        {
            var car = _carService.GetById(carId);
            if (car.Success)
            {
                return new SuccessDataResult<Car>(car.Data);
            }
            return new ErrorDataResult<Car>(Messages.CarNotFound);
        }

        private IResult CarImageCountControl(int carId)
        {
            var car = _carImageDal.GetAll(i=>i.CarId==carId);
            if (car.Count()<6)
            {
                return new SuccessResult();
            }
            return new ErrorResult("5 adet fotoğraf bulundu");
        }

        public IResult Delete(int carImageId)
        {
            var getCarImage = DatabaseCarImageCheck(carImageId);
            IResult result = BusinessRules.Run(getCarImage);

            if (result != null)
            {
                return result;
            }
            var delete = CarImagesFileHelper.Delete(getCarImage.Data.ImagePath);
            if (delete.Success)
            {
                _carImageDal.Delete(getCarImage.Data);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return new ErrorResult("Silinemedi");
           
        }

        private IDataResult<CarImage> DatabaseCarImageCheck(int carImageId)
        {
            var result = _carImageDal.Get(i => i.CarId == carImageId);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\default.png";
            var result = _carImageDal.GetAll(i => i.CarImageId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(int carImageId, IFormFile file)
        {
            CarImage carImage = new CarImage();
            var carControl = CarImageControl(carImageId);
            IResult result = BusinessRules.Run(CarImageIdCheck(carImageId),carControl);

            if (result != null)
            {
                return result;
            }
            carImage = carControl.Data;
            var carUpdateFile = CarImagesFileHelper.Update(file, carImage.ImagePath);
            carImage.ImagePath = carUpdateFile;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CarImageIdCheck(int carImageId)
        {
            if (carImageId <= 0)
            {
                return new ErrorResult(Messages.IdError);
            }
            return new SuccessResult();
        }
    }
}
