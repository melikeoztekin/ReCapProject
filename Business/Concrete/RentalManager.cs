using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            if (rental.RentDate != null && rental.ReturnDate !=null)
            {
                _rentalDal.Add(rental);
                Console.WriteLine(rental.CarId + " numaralı araç" + 
                    rental.UserId + " nolu müşteriye "+ 
                    rental.RentDate +" - "+rental.ReturnDate+" tarihleri için kiralandı.");
                return new SuccessResult(Messages.RentalAdded);
            }
            else if(rental.ReturnDate != null && rental.ReturnDate == null)
            {
                Console.WriteLine(rental.CarId + " numaralı araç" +
                    rental.UserId + " nolu müşteriye " +
                    rental.RentDate + " tarihinde kiralandı.");
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
            throw new NotImplementedException();
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
            return new ErrorResult(Messages.RentalCarIdError);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

    }
}
