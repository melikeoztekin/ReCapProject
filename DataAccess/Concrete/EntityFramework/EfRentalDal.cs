using Core.DataAccess.EntityFramework;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             join k in context.Users
                             on m.CustomerId equals k.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.CarId,
                                 CarId = c.CarId,
                                 CustomerId = m.CustomerId,
                                 CarName = c.CarName,
                                 FirstName = k.FirstName,
                                 LastName = k.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CompanyName = m.CompanyName
                             };
                return result.ToList();
            }
        }
        public RentalDetailDto GetRentalDetailsByCarId(int rentalId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = (from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             join k in context.Users
                             on m.CustomerId equals k.Id
                             where r.RentalId == rentalId
                             orderby r.RentalId ascending
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = m.CustomerId,
                                 CarName = c.CarName,
                                 FirstName = k.FirstName,
                                 LastName = k.LastName,
                                 CompanyName = m.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             }).LastOrDefault(); //Bir sıranın son öğesini veya dizi hiçbir öğe içermiyorsa varsayılan değeri döndürür.
                return result;
            }
        }

        public List<RentalDto> RentalDto()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers 
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users 
                             on customer.UserId equals user.Id
                             select new RentalDto 
                             { 
                             RentalId =rental.RentalId,
                             BrandName=brand.BrandName,
                             CarName=car.CarName,
                             UserName=user.FirstName +" "+ user.LastName,
                             RentDate=rental.RentDate,
                             ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
