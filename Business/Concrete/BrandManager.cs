using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Sisteme "+ brand.BrandId +" numaralı " + brand.BrandName + " marka araç bilgisi eklendi.");
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Sistemden " + brand.BrandId +" numaralı "+ brand.BrandName+ " marka araç bilgisi silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            return _brandDal.GetAll(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Sistemde yer alan " + brand.BrandId + " numaralı " + brand.BrandName+ " marka araç bilgisi güncellendi.");
        }

    }
}
