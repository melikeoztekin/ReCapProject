using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapProjectContext>, IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                IQueryable<Brand> brands = from brand in filter is null ? context.Brands : context.Brands.Where(filter)
                                           orderby brand.BrandName
                                           select brand;
                return brands.ToList();
            }
        }
    }
}
