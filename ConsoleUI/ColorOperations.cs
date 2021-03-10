using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class ColorOperations
    {
        public static void ColorList()
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
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void ColorAdd()
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
        }

        public static void ColorDelete()
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
        }

        public static void ColorUpdate(ColorManager colorManager)
        {
            Console.WriteLine("------------RENK GÜNCELLEME İŞLEMİ---------");
            colorManager.Update(new Color { ColorId = 1, ColorName = "Yeşil" });
            Console.WriteLine(Messages.Updated);
        }

    }
}
