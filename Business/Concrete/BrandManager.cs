using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
                return new SuccessResult(Messages.BrandAdded);
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
                    return new SuccessResult(Messages.BrandDeleted);
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

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("No. " + brand.BrandId + " " + brand.BrandName + " brand vehicle information  in the system has been updated.");
            return new Result(true, Messages.BrandUpdated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }
    }
}
