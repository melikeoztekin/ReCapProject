using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Sisteme " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi eklendi.");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Sistemden " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi silindi.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetCarsByColorId(int colorId)
        {
            return _colorDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Sistemde yer alan " + color.ColorId + " numaralı " + color.ColorName + " renk araç bilgisi güncellendi.");
        }

    }
}
