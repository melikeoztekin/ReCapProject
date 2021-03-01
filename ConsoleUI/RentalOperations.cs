using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
   public static class RentalOperations
    {
        public static void RentalList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            Console.WriteLine("-----------KİRALANMIŞ ARAÇ BİLGİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Model Bilgisi = " + rental.CarId + "  |  "
                        + "Kullanıcı No = " + rental.UserId + "  |  "
                        + "Başlangıç Tarihi = " + rental.RentDate + "  --->  "
                        + "Bitiş Tarihi = " + rental.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void RentalAdd()
        {
            Rental _rental = new Rental();
            UserManager userManager = new UserManager(new EfUserDal());
            CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Kullanıcı Şeçiniz (Id olarak giriniz) = ");
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("Id = "+item.UserId+" First Name = "+item.FirstName);
            }
            Console.Write("Kullanıcı Şeçiniz (Id olarak giriniz) =  ");
            _rental.UserId =int.Parse( Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Araç Şeçiniz = ");
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("Araç No =" +item.CarId + " | "
                    +"Marka No = " + item.BrandId + "  |  "
                    + "Renk No = " + item.ColorId + "  |  "
                    + "Model Bilgisi = " + item.CarName + "  |  "
                    + "Model Yılı = " + item.ModelYear + "  |  "
                    + "Araç Açıklaması = " + item.Description + "  --->  "
                    + "Günlük Ücret = " + item.DailyPrice + " TL");
            }
            Console.Write("Araç Şeçiniz (Id olarak giriniz) = ");
            _rental.CarId = int.Parse(Console.ReadLine());
            var carControl = rentalManager.GetRentalCarId(_rental.CarId);
            if (carControl.Success)
            {
                Console.Clear();
                Console.Write("Kiralama süresinin Başlangıcı (g/a/y) = ");
                _rental.RentDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Kiralama süresinin Bitişi (g/a/y) = ");
                _rental.ReturnDate = DateTime.Parse(Console.ReadLine());
                var result = rentalManager.Add(_rental);
                if (result.Success)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(carControl.Message);
            }
        }

        public static void RentalDetete()
        {
            Rental _rental = new Rental();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("-------------ARAÇ KİRALAMA İPTAL İŞLEMİ--------------");
            RentalList();
            Console.Write("Kiralama No = ");
            int rentalId = int.Parse(Console.ReadLine());
            var result = rentalManager.Delete(rentalId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        
    }
}
