using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDto> CarDto(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext recapContext = new ReCapProjectContext())
            {
                IQueryable<CarDto>
                    carDetailsDtos = from car in filter is null ?
                                     recapContext.Cars : recapContext.Cars.Where(filter)
                                     join brand in recapContext.Brands
                                         on car.BrandId equals brand.BrandId
                                     join color in recapContext.Colors
                                         on car.ColorId equals color.ColorId
                                     select new CarDto
                                     {
                                         CarId = car.CarId,
                                         CarName = car.CarName,
                                         BrandName = brand.BrandName,
                                         ColorName = color.ColorName,
                                         ModelYear = car.ModelYear,
                                         DailyPrice = car.DailyPrice,
                                         Description = car.Description,
                                         ImagePath= recapContext.CarImages.Where(image => image.CarId == car.CarId).FirstOrDefault().ImagePath
                                     };
                return carDetailsDtos.ToList();
            }

        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k in context.Colors
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = k.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

    }
}
