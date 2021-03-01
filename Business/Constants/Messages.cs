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
        public static string RentalListed = "Kiralanan araç bilgileri listelendi.";
        public static string UserListed = "Kullanıcı bilgileri listelendi.";

        public static string DailyPriceInvalid = "Araç günlük ücreti 0'dan büyük olmalıdır.";
        public static string CarNameInvalid = "Araç açıklaması en az 2 karakter olmalıdır";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string ColorNameInvalid = "Renk ismi en az 2 karakter olmalıdır."; 
        public static string CompanyNameInvalid = "şirket ismi en az 2 karakter olmalıdır.";

        public static string MaintenanceTime = "Sistem bakım sebebiyle hizmet veremiyor."; 
        public static string Error = "Beklenmedik bir hata oluştu";
        public static string IdError = "Girdiğiniz ID numarası veritabanında bulunamadı";

        public static string CustomerAdded = "Müşteri kaydı ekleme işlemi başarılı.";
        public static string CustomerDeleted = "Müşteri kaydı silme işlemi başarılı.";
        public static string CustomerUpdated = "Müşteri kaydı güncelleme işlemi başarılı.";

        public static string RentalAdded = "Araç kiralama işlemi başarılı.";
        public static string RentalDeleted = "Araç kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Araç kiralama işlemi güncellemesi başarılı.";
        public static string RentalFailed = "Araç müşteri tarafından teslim edilmediği için şuan kiralanamaz.";
        public static string RentalReturn = "Araç teslim alındı.";
        public static string RentalCarIdError= "Araç şuan başka bir müşteride olduğu için kiralanamaz.";

        public static string UserAdded = "Kullanıcı kaydı başarılı.";
        public static string UserDeleted = "Kullanıcı kaydı silindi.";
    }
}
