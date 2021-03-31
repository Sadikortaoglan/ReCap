using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    //public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    //{
    //    public List<CarDetailDto> GetCarDetails()
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {
    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where brand.BrandId == brandId
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where color.Id == colorId
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }

    //    public CarDetailDto GetCarDetailById(int id)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where car.Id == id
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().FirstOrDefault();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByBrandName(string brandName)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where brand.BrandName == brandName
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByColorName(string colorName)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where color.Name == colorName
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.BrandName,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByFilter(CarFilterDto carFilterDto)
    //    {
    //        using (ReCapContext context = new ReCapContext())
    //        {

    //            var result = from car in context.Cars
    //                         join color in context.Colors
    //                         on car.ColorId equals color.Id
    //                         join brand in context.Brands
    //                         on car.BrandId equals brand.BrandId
    //                         where color.Name == carFilterDto.ColorName
    //                         && brand.BrandName == carFilterDto.BrandName
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = brand.Name,
    //                             ColorName = color.Name,
    //                             ModelYear = car.ModelYear,
    //                             DailyPrice = car.DailyPrice,
    //                             Description = car.Description,
    //                             CarId = car.Id
    //                         };
    //            return result.AsNoTracking().ToList();
    //        }
    //    }
    //}
}
