using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine(brand.BrandId + " numaralı " + brand.BrandName + " marka bilgisi sisteme eklendi.");
                return new SuccessResult(Messages.Added);
            }
            else if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(int brandId)
        {
            try
            {
                var brandBul = _brandDal.Get(b => b.BrandId == brandId);
                if (brandBul != null)
                {
                    _brandDal.Delete(brandBul);
                    return new SuccessResult(Messages.Deleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.IdError);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<List<Brand>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("No. " + brand.BrandId + " " + brand.BrandName+ " brand vehicle information  in the system has been updated.");
            return new Result(true, Messages.Updated);
        }

    }
}
