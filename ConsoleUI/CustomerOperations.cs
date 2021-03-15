using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CustomerOperations
    {
        public static void CustomerList()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            Console.WriteLine("------MÜŞTERİ BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Müşteri No = " + customer.CustomerId + "  |  " + "Şirket Adı = " + customer.CompanyName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void CustomerAdd()
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
        }

        public static void CustomerDelete()
        {
            Customer _customer = new Customer();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("-------------MÜŞTERİ SİLME İŞLEMİ--------------");
            Console.Write("Müşteri No = ");
            int customerId = int.Parse(Console.ReadLine());
            var result = customerManager.Delete(customerId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void CustomerUpdate(CustomerManager customerManager)
        {
            Console.WriteLine("------------MÜŞTERİ BİLGİSİ GÜNCELLEME İŞLEMİ---------");
            customerManager.Update(new Customer { CustomerId = 3, CompanyName = "Umut Grup" });
            Console.WriteLine(Messages.CustomerUpdated);
        }

    }
}
