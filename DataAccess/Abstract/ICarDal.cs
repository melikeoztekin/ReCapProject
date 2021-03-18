using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDto> CarDto();
        List<CarDetailDto> GetCarDetails();
        List<CarDto> CarDtoByBrandId(int brandId);
        List<CarDto> CarDtoByColorId(int colorId);
    }
}
