using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CarRentalControl(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        private IResult CarRentalControl(int carId)
        {
            var results = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate != null && r.ReturnDate <= DateTime.Now);
            if (results.Count != 0)
            {
                var resultK = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate >DateTime.Now );
                if (resultK.Count == 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.RentalFailed);
            }
            else
            {
                var resultsC = _rentalDal.GetAll(r => r.CarId == carId);
                if (resultsC.Count == 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.RentalFailed);
            }
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(int rentalId)
        {
            try
            {
                var rentalBul = _rentalDal.Get(r => r.RentalId == rentalId);
                if (rentalBul != null)
                {
                    _rentalDal.Delete(rentalBul);
                    return new SuccessResult(Messages.RentalDeleted);
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
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            using (var reCapProjectContext = new ReCapProjectContext())
            {
                reCapProjectContext.Rentals.Update(rental);
                reCapProjectContext.SaveChanges();
                return new Result(true, Messages.RentalUpdated);
            }
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IResult GetRentalCarId(int carId)
        {
            var results = _rentalDal.GetAll(p=>p.CarId==carId&&p.ReturnDate==null ||p.CarId == carId&&p.ReturnDate>DateTime.Now);
            if (results.Count==0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.IdError);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheAspect]
        public IDataResult<List<RentalDto>> GetRentalDto()
        {
            var result = _rentalDal.RentalDto();
            if(result.Count==0)
            {
                return new ErrorDataResult<List<RentalDto>>("Veri bulunamadı.");
            }
            return new SuccessDataResult<List<RentalDto>>(result, Messages.RentalListed);
        }
    }
}
