# ReCapProject - Araç Kiralama Sistemi

Proje katmanlı mimariye uygun bir şekilde tasarlanıp, OOP olarak Entity Framework kullanılmıştır.IoC prensibi ve SOLID ilkeleri ile geliştirilmeye devam ediliyor.AutoFac ve FluentValidation paketleri kullanılıyor.Projede web api kullanılmaktadır.

## Proje Katmanları

* ### Entities Layer(.Net Standart)
* Veritabanı nesneleri için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü *  * somut nesneleri tutmak için oluşturulmuştur.

* ### Business Layer(.Net Standart)
* Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan Business Katmanı'nda Abstract,Concrete,Utilities ve ValidationRules olmak * * * üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde * validation işlemlerinin gerçekleştiği classlar mevcuttur.


* ### Data Access(.Net Standart)
* Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut * * * * nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.

* ### Core Layer(.Net Standart)

* **Dikkat!!!** Core Katmanı, diğer katmanları referans almaz.
* Bir framework katmanı olan Core Katmanı'nda DataAccess, Entities, Utilities olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.

* ### WebAPI



Nuget
- [ ] Autofac Version="6.1.0"
- [ ] Autofac.Extensions.DependencyInjection Version="7.1.0"
- [ ] Autofac.Extras.DynamicProxy Version="6.0.0"
- [ ] FluentValidation Version="9.5.1"
- [ ] Microsoft.AspNetCore.Http Version="2.2.2"
- [ ] Microsoft.AspNetCore.Http.Features Version="5.0.3"
- [ ] Microsoft.AspNetCore.Http.Abstractions Version="2.2.0"
- [ ] Microsoft.EntityFrameworkCore.SqlServer Version="3.1.1"
- [ ] Microsoft.IdentityModel.Tokens Version="6.8.0"
- [ ] System.IdentityModel.Tokens.Jwt Version="6.8.0"

