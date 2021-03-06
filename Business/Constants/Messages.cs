﻿using Entities.Concrete;
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
        public static string MaintenanceTime = "Sistem bakım sebebiyle hizmet veremiyor.";
        public static string Error = "Beklenmedik bir hata oluştu";
        public static string IdError = "Girdiğiniz ID numarası veritabanında bulunamadı";
        public static string NotEmpty = "Alanlar boş geçilemez";

        public static string DailyPriceInvalid = "Araç günlük ücreti 0'dan büyük olmalıdır.";
        public static string CarNameInvalid = "Araç ismi en az 2 karakter olmalıdır";
        public static string DescriptionInvalid = "Araç açıklaması en az 2 karakter olmalıdır";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string ColorNameInvalid = "Renk ismi en az 2 karakter olmalıdır."; 
        public static string CompanyNameInvalid = "şirket ismi en az 2 karakter olmalıdır.";

        public static string CarAdded = "Yeni araç ekleme işlemi başarıyla gerçekleşti.";
        public static string CarDeleted = "Araç bilgileri sistemden silindi.";
        public static string CarUpdated = "Araç bilgisi güncelleme işlemi başarılı.";
        public static string CarListed = "Araç bilgileri listelendi.";
        public static string CarNotFound = "Araç bulunamadı.";

        public static string BrandAdded = "Yeni marka bilgisi ekleme işlemi başarılı.";
        public static string BrandDeleted = "Marka bilgileri sistemden silindi.";
        public static string BrandUpdated = "Marka bilgisi güncelleme işlemi başarılı.";
        public static string BrandListed = "Marka bilgileri listelendi.";
        public static string BrandNameAlreadyExists = "Aynı isimde marka bilgisi mevcut.";

        public static string ColorAdded = "Yeni renk bilgisi ekleme işlemi başarılı.";
        public static string ColorDeleted = "Renk bilgileri sistemden silindi.";
        public static string ColorUpdated = "Renk bilgisi güncelleme işlemi başarılı.";
        public static string ColorListed = "Renk bilgileri listelendi.";
        public static string ColorNameAlreadyExists = "Aynı isimde renk bilgisi mevcut.";

        public static string CustomerAdded = "Müşteri kaydı ekleme işlemi başarılı.";
        public static string CustomerDeleted = "Müşteri kaydı silme işlemi başarılı.";
        public static string CustomerUpdated = "Müşteri kaydı güncelleme işlemi başarılı.";
        public static string CustomerListed = "Müşteri bilgileri listelendi"; 
        public static string CompanyNameAlreadyExists = "Aynı isimde şirket bilgisi mevcut.";

        public static string RentalAdded = "Yeni araç kiralama işlemi başarılı.";
        public static string RentalDeleted = "Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Kiralama işlemi güncellemesi başarılı.";
        public static string RentalListed = "Kiralanan araç bilgileri listelendi.";
        public static string RentalFailed = "Bu araç şuan başka müşteri tarafından kiralandığı için kiralanamaz.";
        public static string RentalReturn = "Araç teslim alındı.";

        public static string UserAdded = "Yeni kulanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı kaydı silindi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi";
        public static string UserEmailAlreadyExists = "Aynı e-posta ile daha önce kayıt yapılmış.";
        public static string UserListed = "Kullanıcı bilgileri listelendi";
        public static string UserRegistered = "Kullanıcı kaydı yapıldı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Kullanıcı parolası yanlış.";
        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string UserAlreadyExists = "Sistemde kayıtlı kullanıcı.";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string CarImageAdded = "Araç resmi başarıyla eklendi";
        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi";
        public static string CarImageNotFound = "Araca ait resim bulunamadı";
        public static string CarImageNotDeleted = "Resim silme başarısız.";
        public static string CarImageEnough = "Araca ait en fazla 5 fotoğraf eklenebilir.";


        public static string AuthorizationDenied = "Bu işlemi yapmak için yetkiniz yok.";
    }
}
