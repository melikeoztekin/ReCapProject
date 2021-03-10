using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CarOperations
    {
        public static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            Console.WriteLine("-----------GÜNLÜK ÜCRET KİRA BİLGİSİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Marka No = " + car.BrandId + "  |  "
                        + "Renk No = " + car.ColorId + "  |  "
                        + "Model Bilgisi = " + car.CarName + "  |  "
                        + "Model Yılı = " + car.ModelYear + "  |  "
                        + "Araç Açıklaması = " + car.Description + "  --->  "
                        + "Günlük Ücret = " + car.DailyPrice + " TL");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void CarAdd()
        {
            Car _car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------ARAÇ EKLEME İŞLEMİ--------------");
            Console.Write("Marka No = ");
            _car.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Renk No = ");
            _car.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Model Bilgisi = ");
            _car.CarName = Console.ReadLine();
            Console.Write("Model Yılı = ");
            _car.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Günlük Ücreti = ");
            _car.DailyPrice = int.Parse(Console.ReadLine());
            Console.Write("Araç Açıklaması = ");
            _car.Description = Console.ReadLine();
            var result = carManager.Add(_car);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void CarDelete()
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
        }

        public static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("------------GÜNCELLEME İŞLEMİ---------");
            carManager.Update(new Car { CarId = 3, BrandId = 3, 
                ColorId = 5, CarName = "ALFA ROMEO GIULIA", 
                ModelYear = 2020, DailyPrice = 850, Description = "Sigortası Yapıldı" });
            Console.WriteLine(Messages.Updated);
        }
    }
}
