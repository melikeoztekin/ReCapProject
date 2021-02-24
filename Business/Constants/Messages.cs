using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string Updated = "Güncelleme işlemi başarılı.";
        public static string CarsListed = "Araç bilgileri listelendi.";
        public static string BrandsListed = "Araç marka bilgileri listelendi.";
        public static string ColorsListed = "Araç renk bilgileri listelendi.";
        public static string CustomersListed = "Müşteri bilgileri listelendi.";
        public static string MaintenanceTime = "Sistem bakım sebebiyle hizmet veremiyor.";
        public static string DailyPriceInvalid = "Araç günlük ücreti 0'dan büyük olmalıdır.";
        public static string DescriptionInvalid = "Araç açıklaması en az 2 karakter olmalıdır";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string ColorNameInvalid = "Renk ismi en az 2 karakter olmalıdır.";
        public static string Error = "Beklenmedik bir hata oluştu";
        public static string IdError = "Girdiğiniz ID numarası veritabanında bulunamadı";
        public static string CustomerAdded = "Müşteri kaydı ekleme işlemi başarılı.";
        public static string CustomerDeleted = "Müşteri kaydı silme işlemi başarılı.";
        public static string CustomerUpdated = "Müşteri kaydı güncelleme işlemi başarılı.";
        public static string CompanyNameInvalid = "şirket ismi en az 2 karakter olmalıdır.";
    }
}
