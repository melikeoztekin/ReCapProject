using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI2
{
    //Burası ödevden bağımsız olarak sadece iyileştirme yapmak amacıyla kullandığım bir console
    class Program
    {
        static void Main(string[] args)
        {
            bool Durum = true;
            while (Durum == true)
            {
                Console.WriteLine("Tablo Seçiniz Car{C},Brand {B} Color{CO}");
                string islem = Console.ReadLine();
                if (islem.ToUpper() == "C")
                {
                    CarIslem();
                }
                else if (islem.ToUpper() == "B")
                {
                    BrandIslem();
                }
                else if (islem.ToUpper() == "CO")
                {

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı Şeçenek");
                }
            }
        }

        private static void CarIslem()
        {
            bool Durum = true;
            while (Durum == true)
            {
                Console.WriteLine("****** Araba işlemleri ******");
                Console.Write("Sisteme girmek için Yes {Y} / Çıkmak için Exit {E} =");
                string islem = Console.ReadLine().ToUpper();
                if (islem == "Y")
                {
                    Console.Write("Araba İşlemleri Add(A), Update(U), Delete(D), List(L) =");
                    string islem2 = Console.ReadLine().ToUpper();
                    if (islem2 == "A")
                    {
                        AddCar();
                    }
                    else if (islem2 == "D")
                    {

                    }
                    else if (islem2 == "U")
                    {

                    }
                    else if (islem2 == "L")
                    {

                    }
                }
                else if (islem == "E")
                {
                    Console.Clear();
                    Durum = false;
                }
            }
        }

        public static void AddCar()
        {
            Car _car = new Car();
            CarManager _carManager = new CarManager(new EfCarDal());
            bool durum = true;
            while (durum == true)
            {
                Console.Clear();
                Console.WriteLine("********* Araba Ekleme ***********");
                Console.WriteLine("Brand Id");
                _car.BrandId = int.Parse(Console.ReadLine());
                Console.WriteLine("ColorId Id");
                _car.ColorId = int.Parse(Console.ReadLine());
                Console.WriteLine("Car Name");
                _car.CarName = Console.ReadLine();
                Console.WriteLine("DailyPrice");
                _car.DailyPrice = int.Parse(Console.ReadLine());
                Console.WriteLine("Model Year");
                _car.ModelYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Description");
                _car.Description = Console.ReadLine();
                Console.WriteLine("Araba Eklensinmi Yes (Y) / No (N)");
                string islemKarar = Console.ReadLine().ToUpper();
                if (islemKarar=="Y")
                {
                    var result = _carManager.Add(_car);                 
                    Console.Clear();
                    Console.WriteLine(result.Message);
                }
                else if(islemKarar=="N")
                {
                    durum = false;
                    Console.Clear();                  
                }
            }
        }
        public static void BrandIslem()
        {
            bool Durum = true;
            while (Durum == true)
            {
                Console.WriteLine("********* Brand İşlemleri ***********");
                Console.Write("Sisteme girmek için Yes {Y}, çıkmak için Exit {E} = ");
                string islem = Console.ReadLine().ToUpper();
                if (islem == "Y")
                {
                    Console.Write("Marka işlemleri Add(A), Update(U),Delete(D),List(L) = ");
                    string islemB = Console.ReadLine().ToUpper();
                    if (islemB=="A")
                    {
                        AddBrand();
                    }
                }
                if (islem == "E")
                {
                    Console.Clear();
                    Durum = false;
                }
            }
        }

        private static void AddBrand()
        {
            Brand _brand = new Brand();
            BrandManager _brandManager = new BrandManager(new EfBrandDal());
            bool durum = true;
            while (durum == true)
            {
                Console.Clear();
                Console.WriteLine("******** Marka Ekleme *******");
                Console.WriteLine("Brand Name = ");
                _brand.BrandName = Console.ReadLine();
                Console.Write("Marka bilgisi eklensin mi ? Yes {Y}, No {N} = ");
                string karar = Console.ReadLine().ToUpper();
                if (karar=="Y")
                {
                    var result = _brandManager.Add(_brand);
                    Console.WriteLine(result.Message);
                    Console.ReadKey();
                }
                else if (karar == "N")
                {
                    durum = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Yanlış giriş yapıldı.");
                }
            }
        }
    }
}
