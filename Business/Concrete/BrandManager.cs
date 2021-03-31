using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess;

namespace Business.Concrete
{

    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }


        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.BrandId == brandId));
        }


        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }


    }



}
