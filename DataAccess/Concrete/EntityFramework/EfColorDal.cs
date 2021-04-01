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
    public class EfColorDal : EfEntityRepositoryBase<Color, ReCapProjectContext>, IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                IQueryable<Color> colors = from color in filter is null ? context.Colors : context.Colors.Where(filter)
                                           orderby color.ColorName
                                           select color;
                return colors.ToList();
            }
        }
    }
}
