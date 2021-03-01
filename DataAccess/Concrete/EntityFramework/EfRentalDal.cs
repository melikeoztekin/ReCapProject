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
                             on r.UserId equals m.UserId
                             join k in context.Users
                             on m.UserId equals k.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.CarId,
                                 CarId = c.CarId,
                                 UserId = m.UserId,
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
                             on r.UserId equals m.UserId
                             join k in context.Users
                             on m.UserId equals k.UserId
                             where r.RentalId == rentalId
                             orderby r.RentalId ascending
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 UserId = m.UserId,
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

    }
}
