using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public static class UserOperations
    {
        public static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            Console.WriteLine("-----------KULLANICI BİLGİSİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("Adı = " + user.FirstName + "  |  "
                        + "Soyadı = " + user.LastName + "  |  "
                        + "Email Adresi = " + user.Email );
                }
                Console.WriteLine(Messages.UserListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void UserAdd()
        {
            User _user = new User();
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("-------------KULLANICI EKLEME İŞLEMİ--------------");
            Console.Write("Adı = ");
            _user.FirstName = Console.ReadLine();
            Console.Write("Soyadı = ");
            _user.LastName = Console.ReadLine();
            Console.Write("Email adresi = ");
            _user.Email = Console.ReadLine();
            Console.Write("Parola = ");
            _user.Password = int.Parse(Console.ReadLine());
            var result = userManager.Add(_user);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void UserDelete()
        {
            User _userr = new User();
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("-------------KULLANICI SİLME İŞLEMİ--------------");
            Console.Write("Kullanıcı No = ");
            int userId = int.Parse(Console.ReadLine());
            var result = userManager.Delete(userId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void UserUpdate(UserManager userManager)
        {
            Console.WriteLine("------------KULLANICI BİLGİSİ GÜNCELLEME İŞLEMİ---------");
            userManager.Update(new User { UserId = 1002, FirstName = "Umut", LastName = "Beldek",Email= "umutkayra@gmail.com", Password = 123456 });
            Console.WriteLine(Messages.Updated);
        }

    }
}
