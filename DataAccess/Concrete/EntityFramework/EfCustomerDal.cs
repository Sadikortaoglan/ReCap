using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from user in context.Users
                    join customer in context.Customers on user.Id equals customer.UserId
                    select new CustomerDetailDto
                    {
                        CustomerId = customer.UserId,
                        CompanyName = customer.CompanyName,
                        CustomerName = $"{user.FirstName}{user.LastName}"
                    };
                return result.ToList();
            }
        }
    }
}
