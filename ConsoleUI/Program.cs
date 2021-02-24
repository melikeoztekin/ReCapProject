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
            bool Durum = true;
            while (Durum==true)
            {
                Console.Write("İşlem Seçiniz --> Ekleme {A} - Silme {D} - Güncelleme {U} - Listeleme {L} = ");
                string islem = Console.ReadLine();
                if (islem == "A")
                {
                    Console.Write("Eklemek istediğiniz nedir? --> Yeni Araç {C} - Marka {B} - Renk {K} - Müşteri ekleme {M} = ");
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
                    else if (aIslem == "M")
                    {
                        AddCustomer();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "D")
                {
                    Console.Write("Silmek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Müşteri {M} = ");
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
                    else if (dIslem == "M")
                    {
                        DeleteCustomer();
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
                else if (islem == "L")
                {
                    Console.Write("Listelemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Müşteri {M} = ");
                    string lIslem = Console.ReadLine();
                    if (lIslem == "C")
                    {
                        CarTest();
                    }
                    else if (lIslem == "B")
                    {
                        BrandTest();
                    }
                    else if (lIslem == "K")
                    {
                        ColorTest();
                    }
                    else if (lIslem == "M")
                    {
                        CustomerTest();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
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
            Console.WriteLine("-----------GÜNLÜK ÜCRET KİRA BİLGİSİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Marka No = " + car.BrandId + "  |  "
                        + "Renk No = " + car.ColorId + "  |  "
                        + "Model Yılı = " + car.ModelYear + "  |  "
                        + "Marka Model = " + car.Descriptions + "  --->  "
                        + "Günlük Ücret = " + car.DailyPrice + " TL");
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
            Console.WriteLine("------ARAÇ MARKA BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Marka No = " + brand.BrandId + "  |  " + "Marka Adı= " + brand.BrandName);
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
            Console.WriteLine("------ARAÇ RENK BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("Renk No = " + color.ColorId + "  |  " + "REnk Adı = " + color.ColorName);
                }
                Console.WriteLine(Messages.ColorsListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(" ");
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            Console.WriteLine("------MÜŞTERİ BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Müşteri No = " + customer.UserId + "  |  " + "Şirket Adı = " + customer.CompanyName);
                }
                Console.WriteLine(Messages.CustomersListed);
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
            Console.WriteLine("-------------ARAÇ EKLEME İŞLEMİ--------------");
            Console.Write("Marka No = ");
            _car.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Renk No = ");
            _car.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Model Yılı = ");
            _car.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Günlük Ücreti = ");
            _car.DailyPrice = int.Parse(Console.ReadLine());
            Console.Write("Marka Model Adı = ");
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
            Console.ReadKey();
        }
        private static void AddColor()
        {
            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("-------------RENK EKLEME İŞLEMİ--------------");
            Console.Write("Renk Adı = ");
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
        private static void AddCustomer()
        {
            Customer _customer = new Customer();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("-------------MÜŞTERİ EKLEME İŞLEMİ--------------");
            Console.Write("Şirket Adı = ");
            _customer.CompanyName = Console.ReadLine();
            var result = customerManager.Add(_customer);
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
            Console.WriteLine("-------------ARAÇ SİLME İŞLEMİ--------------");
            Console.Write("Araç No = ");
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
            Console.ReadKey();
        }
        private static void DeleteColor()
        {
            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("-------------RENK SİLME İŞLEMİ--------------");
            Console.Write("Renk No = ");
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
        private static void DeleteCustomer()
        {
            Customer _customer = new Customer();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("-------------MÜŞTERİ SİLME İŞLEMİ--------------");
            Console.Write("Müşteri No = ");
            int userId = int.Parse(Console.ReadLine());
            var result = customerManager.Delete(userId);
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
            Console.WriteLine("------------GÜNCELLEME İŞLEMİ---------");
            carManager.Update(new Car { Id = 3002, BrandId = 3, ColorId = 5, ModelYear = 2020, DailyPrice = 850, Descriptions = "ALFA ROMEO GIULIA" });
            brandManager.Update(new Brand { BrandId = 3002, BrandName = "ALFA ROMEO" });
            colorManager.Update(new Color { ColorId = 3002, ColorName = "Silver" });
            Console.WriteLine(Messages.Updated);
        }
        
    }
}
