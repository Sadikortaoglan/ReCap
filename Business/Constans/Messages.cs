using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constans
{
    public class Messages
    {
        //Düzenlemer yapılacak 
        public static string BrandNameInvalid = "Marka adı en az 3 karakter olmalıdır.";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Markalar listelendi";

        public static string MaintenanceTime = "Sistem şuan bakımda.";

        internal static string CarImageLimitExceeded = "Sınırlı aştınız.";
        public static string CarAdded = "Araç başarılı bir şekilde eklendi";
        public static string CarDeleted = "Araç başarılı bir şekilde silindi";
        public static string CarListed = "Bütün arabalar listelendi";
        public static string CarUpdated = "Güncellendi";
        public static string CarPriceInvalid = "Bulunamadı";

        public static string ColorNameInvalid = "Renk bulunamadı";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorListed = "Renkler Listelendi";


        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Eklendi";
        public static string CompanyNameInvalid = "Firma adı en az 4 karakter olmalıdır.";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";
        public static string CustomerDeleted = "Müşteri bilgileri silindi.";

        public static string NotReturnDate = "Araç henüz teslim edilmedi";
        public static string RentalAdded = "Araç Kiralandı";
        public static string RetalDeleted = "Araç Silindi";
        public static string RentalListed = "Araçlar Listelendi";
        public static string RentalUpdated = "Araç güncellendi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";


        public static string AuthorizationDenied = "Giriş Engellendi.";
        public static string UserAlreadyExists = "";
        public static string AccessTokenCreated = "";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string PasswordError = "Yanlış şifre";
        public static string UserNotFound = "Kullanıcı bululnamadı";
        public static string UserRegistered = "Kullanıcı kaydedildi";
    }
}