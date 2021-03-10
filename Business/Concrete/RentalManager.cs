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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.RentDate != null && rental.ReturnDate != null)
            {
                var result = _rentalDal.GetAll(r=>r.CarId==rental.CarId && r.ReturnDate>DateTime.Now);
                if (result.Count!=0)
                {
                    var result2 = _rentalDal.GetAll(r=>r.CarId==rental.CarId);
                    if (result2.Count==0)
                    {
                        _rentalDal.Add(rental);
                        return new SuccessResult(Messages.RentalAdded);
                    }
                    return new ErrorResult(Messages.RentalFailed);
                }
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else if (rental.ReturnDate != null && rental.ReturnDate == null)
            {
                return new SuccessResult(Messages.RentalFailed);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }

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

        public IResult Update(Rental rental)
        {
            using (var reCapProjectContext = new ReCapProjectContext())
            {
                reCapProjectContext.Rentals.Update(rental);
                reCapProjectContext.SaveChanges();
                return new Result(true, Messages.RentalUpdated);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            //if (DateTime.Now.Hour == 21)
            //{
            //    return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

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

    }
}
