using Business.Concrete;
using Business.Constants;
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
            bool Durum = true;
            while (Durum==true)
            {
                Console.WriteLine("İşlem Seçiniz --> Ürün Ekleme {A} - Silme {D} - Güncelleme {U}");
                string islem = Console.ReadLine();
                if (islem == "A")
                {
                    Console.WriteLine("Eklemek istediğiniz nedir? --> Yeni Araç {C} - Marka {B} - Renk {K}");
                    string aIslem = Console.ReadLine();
                    if (aIslem == "C")
                    {
                        AddCar();
                    }
                    else if (aIslem == "B")
                    {
                        AddBrand();
                    }
                    else if (aIslem == "K")
                    {
                        AddColor();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "D")
                {
                    Console.WriteLine("Silmek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K}");
                    string dIslem = Console.ReadLine();
                    if (dIslem == "C")
                    {
                        DeleteCar();
                    }
                    else if (dIslem == "B")
                    {
                        DeleteBrand();
                    }
                    else if (dIslem == "K")
                    {
                        DeleteColor();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "U")
                {
                    CarManager carManager = new CarManager(new EfCarDal());
                    BrandManager brandManager = new BrandManager(new EfBrandDal());
                    ColorManager colorManager = new ColorManager(new EfColorDal());
                    UpdateTest(carManager, brandManager, colorManager);
                }
                else
                {
                    Console.WriteLine("Hatalı bir işlem seçtiniz.");
                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            Console.WriteLine("-----------DAILY CAR RENTAL PRICES-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                        + "Color Id = " + car.ColorId + "  |  "
                        + "Model Year = " + car.ModelYear + "  |  "
                        + "Description = " + car.Descriptions + "  --->  "
                        + "Daily Price = " + car.DailyPrice + " TL");
                }
                Console.WriteLine(Messages.CarsListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(" ");
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            Console.WriteLine("------VECIHLE BRAND ID AND VECIHLE BRAND NAME------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
                }
                Console.WriteLine(Messages.BrandsListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(" ");
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            Console.WriteLine("------VECIHLE COLOR ID AND VECIHLE COLOR NAME------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("Color Id = " + color.ColorId + "  |  " + "Color Name = " + color.ColorName);
                }
                Console.WriteLine(Messages.ColorsListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(" ");
        }
        private static void AddCar()
        {
            Car _car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------INSERTION OPERATOR TEST--------------");
            Console.Write("Brand Id = ");
            _car.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Color Id = ");
            _car.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Model Year = ");
            _car.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("DailyPrice = ");
            _car.DailyPrice = int.Parse(Console.ReadLine());
            Console.Write("Descriptions = ");
            _car.Descriptions = Console.ReadLine();
            var result = carManager.Add(_car);
            if (result.Success == true)
            {          
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadKey();
        }
        private static void AddBrand()
        {
            Brand _brand = new Brand();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("-------------INSERTION OPERATOR TEST--------------");
            Console.Write("Brand Name = ");
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
            Console.ReadKey();
        }
        private static void AddColor()
        {
            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("-------------INSERTION OPERATOR TEST--------------");
            Console.Write("Color Name = ");
            _color.ColorName = Console.ReadLine();
            var result = colorManager.Add(_color);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadKey();
        }
        private static void DeleteCar()
        {
            Car _car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
            Console.Write("Car Id = ");
            int carId = int.Parse(Console.ReadLine());
            var result = carManager.Delete(carId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadKey();
        }
        private static void DeleteBrand()
        {
            Brand _brand = new Brand();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
            Console.Write("Brand Id = ");
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
            Console.ReadKey();
        }
        private static void DeleteColor()
        {
            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
            Console.Write("Color Id = ");
            int colorId = int.Parse(Console.ReadLine());
            var result = colorManager.Delete(colorId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadKey();
        }
        private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------UPDATION OPERATOR TEST---------");
            carManager.Update(new Car { Id = 3002, BrandId = 3, ColorId = 5, ModelYear = 2020, DailyPrice = 850, Descriptions = "ALFA ROMEO GIULIA" });
            brandManager.Update(new Brand { BrandId = 3002, BrandName = "ALFA ROMEO" });
            colorManager.Update(new Color { ColorId = 3002, ColorName = "Silver" });
            Console.WriteLine(Messages.Updated);
        }
    }
}
