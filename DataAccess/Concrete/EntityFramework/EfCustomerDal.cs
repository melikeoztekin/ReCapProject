using Core.DataAccess.EntityFramework;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from m in context.Customers
                             join k in context.Users
                             on m.CustomerId equals k.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = m.CustomerId,
                                 UserId = k.Id,
                                 CompanyName = m.CompanyName
                             };
                return result.ToList();
            }
        }

    }
}
