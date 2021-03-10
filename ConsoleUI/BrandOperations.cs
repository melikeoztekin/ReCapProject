using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class BrandOperations
    {
        public static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            Console.WriteLine("------ARAÇ MARKA BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Marka No = " + brand.BrandId + "  |  " + "Marka Adı= " + brand.BrandName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void BrandAdd()
        {
            Brand _brand = new Brand();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("-------------MARKA EKLEME İŞLEMİ--------------");
            Console.Write("Marka Adı = ");
            _brand.BrandName = Console.ReadLine();
            var result = brandManager.Add(_brand);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void BrandDelete()
        {
            Brand _brand = new Brand();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("-------------MARKA SİLME İŞLEMİ--------------");
            Console.Write("Marka No = ");
            int brandId = int.Parse(Console.ReadLine());
            var result = brandManager.Delete(brandId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void BrandUpdate(BrandManager brandManager)
        {
            Console.WriteLine("------------MARKA GÜNCELLEME İŞLEMİ---------");
            brandManager.Update(new Brand { BrandId = 3002, BrandName = "ALFA ROMEO" });
            Console.WriteLine(Messages.Updated);
        }

    }
}
