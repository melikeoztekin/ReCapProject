using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class SelectOperations
    {
        public static void SelectOperation()
        {
            bool Durum = true;
            while (Durum == true)
            {
                Console.Write("İşlem Seçiniz --> Ekleme {A} - Silme {D} - Güncelleme {U} - Listeleme {L} = ");
                string islem = Console.ReadLine();
                if (islem == "A")
                {
                    Console.Write("Eklemek istediğiniz nedir? --> Yeni Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} - Kiralama {R} = ");
                    string islemA = Console.ReadLine();
                    if (islemA == "C")
                    {
                        CarOperations.CarAdd();
                    }
                    else if (islemA == "B")
                    {
                        BrandOperations.BrandAdd();
                    }
                    else if (islemA == "K")
                    {
                        ColorOperations.ColorAdd();
                    }
                    else if(islemA == "U")
                    {
                        UserOperations.UserAdd();
                    }
                    else if (islemA == "M")
                    {
                        CustomerOperations.CustomerAdd();
                    }
                    else if (islemA == "R")
                    {
                        RentalOperations.RentalAdd();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "D")
                {
                    Console.Write("Silmek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} - Kira İptal {R} = ");
                    string islemD = Console.ReadLine();
                    if (islemD == "C")
                    {
                        CarOperations.CarDelete();
                    }
                    else if (islemD == "B")
                    {
                        BrandOperations.BrandDelete();
                    }
                    else if (islemD == "K")
                    {
                        ColorOperations.ColorDelete();
                    }
                    else if (islemD == "U")
                    {
                        UserOperations.UserDelete();
                    }
                    else if (islemD == "M")
                    {
                        CustomerOperations.CustomerDelete();
                    }
                    else if (islemD == "R")
                    {
                        RentalOperations.RentalDetete();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "U")
                {
                    Console.Write("Güncellemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} = ");
                    string islemU = Console.ReadLine();
                    if (islemU == "C")
                    {
                        CarManager carManager = new CarManager(new EfCarDal());
                        CarOperations.CarUpdate(carManager);
                    }
                    else if (islemU == "B")
                    {
                        BrandManager brandManager = new BrandManager(new EfBrandDal());
                        BrandOperations.BrandUpdate(brandManager);
                    }
                    else if (islemU == "K")
                    {
                        ColorManager colorManager = new ColorManager(new EfColorDal());
                        ColorOperations.ColorUpdate(colorManager);
                    }
                    else if (islemU == "U")
                    {
                        UserManager userManager = new UserManager(new EfUserDal());
                        UserOperations.UserUpdate(userManager);
                    }
                    else if (islemU == "M")
                    {
                        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                        CustomerOperations.CustomerUpdate(customerManager);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else if (islem == "L")
                {
                    Console.Write("Listelemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} - Kiralı araçlar {R} = ");
                    string islemL = Console.ReadLine();
                    if (islemL == "C")
                    {
                        CarOperations.CarList();
                    }
                    else if (islemL == "B")
                    {
                        BrandOperations.BrandList();
                    }
                    else if (islemL == "K")
                    {
                        ColorOperations.ColorList();
                    }
                    else if (islemL == "U")
                    {
                        UserOperations.UserList();
                    }
                    else if (islemL == "M")
                    {
                        CustomerOperations.CustomerList();
                    }
                    else if (islemL == "R")
                    {
                        RentalOperations.RentalList();
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
    }
}
