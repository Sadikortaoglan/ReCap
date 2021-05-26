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

namespace Business.Concrete
{
   public class ColorManager:IColorService
   {
       private IColorDal _colorDal;

       public ColorManager(IColorDal colorDal)
       {
           _colorDal = colorDal;
       }
       [ValidationAspect(typeof(ColorValidator))]
       [CacheRemoveAspect("IColorService.Get")]
       [SecuredOperation("Color.Add")]
        public IResult Add(Color color)
        {
            if (color.ColorName.Length<=3)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        [SecuredOperation("Color.Update")]
        public IResult Update(Color color)
        {
           _colorDal.Update(color);
           return new SuccessResult(Messages.ColorUpdated);
        }
        [SecuredOperation("Color.Delete")]
        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
           return new SuccessResult(Messages.ColorDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Color> GetById(int colorId)
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Color>(_colorDal.Get(color => color.ColorId == colorId));
        }
    }
}
