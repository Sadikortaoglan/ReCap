using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("Brand.Add")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        [SecuredOperation("Brand.Delete")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {

            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.BrandListed);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int brandId)
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.BrandId == brandId));
        }

        [SecuredOperation("Brand.Update")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }


    }



}
