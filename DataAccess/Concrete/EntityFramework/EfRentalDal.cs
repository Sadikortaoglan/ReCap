using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from rental in context.Rentals
                    join car in context.Cars on rental.CarId equals car.Id
                    join customer in context.Customers on rental.CustomerId equals customer.Id
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join user in context.Users on customer.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarId = car.Id,
                        CustomerName = customer.CompanyName,
                        UserName = $"{user.FirstName}{user.LastName}",
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                    from rental in context.Rentals.Where(c => c.CarId == id)
                    join car in context.Cars on rental.CarId equals car.Id
                    join cu in context.Customers on rental.CustomerId equals cu.Id
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join user in context.Users on cu.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarId = car.Id,
                        BrandName = brand.BrandName,
                        CustomerName = cu.CompanyName,
                        UserName = $"{user.FirstName} {user.LastName}",
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
