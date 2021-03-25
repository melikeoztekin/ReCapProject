using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(int carId);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDto>> GetCarDto();
        IDataResult<List<CarDto>> GetCarDtoCarId(int CarId);
        IDataResult<List<CarDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDto>> GetByColorId(int colorId);
        Result AddTransactionalTest(Car car);

    }
}
