using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //AddTest(carManager,brandManager, colorManager);
            //UpdateTest(carManager, brandManager, colorManager);
            DeleteTest(carManager, brandManager, colorManager);
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-----------DAILY CAR RENTAL PRICES-----------");
            Console.WriteLine("---------------------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                    + "Color Id = " + car.ColorId + "  |  "
                    + "Model Year = " + car.ModelYear + "  |  "
                    + "Description = " + car.Descriptions + "  --->  "
                    + "Daily Price = " + car.DailyPrice + " TL");
            }
            Console.WriteLine(" ");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------VECIHLE BRAND ID AND VECIHLE BRAND NAME------");
            Console.WriteLine("---------------------------------------------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
            }
            Console.WriteLine(" ");
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------VECIHLE COLOR ID AND VECIHLE COLOR NAME------");
            Console.WriteLine("---------------------------------------------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id = " + color.ColorId + "  |  " + "Color Name = " + color.ColorName);
            }
            Console.WriteLine(" ");
        }
        
        private static void AddTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("-------------INSERTION OPERATOR TEST--------------");
            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = 2015, DailyPrice = 500, Descriptions = "AUDI A4 B8" });
            brandManager.Add(new Brand { BrandName = "AUDI" });
            colorManager.Add(new Color { ColorName = "Gray" });
        }
        private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------UPDATION OPERATOR TEST---------");
            carManager.Update(new Car { Id = 2002, BrandId = 2, ColorId = 1003, ModelYear = 2016, DailyPrice = 550, Descriptions = "AUDI A4 B8" });
            brandManager.Update(new Brand { BrandId = 1003, BrandName = "AUDI" });
            colorManager.Update(new Color { ColorId = 1003, ColorName = "Blue" });
        }
        private static void DeleteTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------DELETION OPERATOR TEST---------");
            carManager.Delete(new Car { Id = 2004, BrandId = 2003, ColorId = 2003, ModelYear = 2005, DailyPrice = 250, Descriptions = "TOYOTA COROLLA" });
            brandManager.Delete(new Brand { BrandId = 2003, BrandName = "TOYOTA" });
            colorManager.Delete(new Color { ColorId = 2003, ColorName = "Yellow" });
        }
    }
}
