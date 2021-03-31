using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

       public IDataResult<Customer> GetById(int customerId)
       {

           if (DateTime.Now.Hour == 00)
           {
               return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
           }

           return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.UserId == customerId));
       }
       public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<=4)
            {
                return new ErrorResult(Messages.CompanyNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
           _customerDal.Update(customer);
           return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            throw new NotImplementedException();
        }
    }
}
