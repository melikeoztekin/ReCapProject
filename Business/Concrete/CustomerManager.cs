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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length > 2)
            {
                _customerDal.Add(customer);
                Console.WriteLine(customer.UserId + " numaralı " + customer.CompanyName + " müşteri bilgisi sisteme eklendi.");
                return new SuccessResult(Messages.CustomerAdded);
            }
            else if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CompanyNameInvalid);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(int userId)
        {
            try
            {
                var customerBul = _customerDal.Get(m => m.UserId == userId);
                if (customerBul != null)
                {
                    _customerDal.Delete(customerBul);
                    return new SuccessResult(Messages.CustomerDeleted);
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

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IDataResult<List<Customer>> GetCustomersById(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(m => m.UserId == userId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            Console.WriteLine("Sistemde yer alan " + customer.UserId + " numaralı " + customer.CompanyName + " şirket bilgisi güncellendi.");
            return new Result(true, Messages.CustomerUpdated);
        }
    }
}
