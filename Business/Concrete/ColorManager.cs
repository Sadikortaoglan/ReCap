using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
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

       public IResult Add(Color color)
        {
            if (color.ColorName.Length<=3)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
           _colorDal.Update(color);
           return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
           return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Color>(_colorDal.Get(color => color.Id == colorId));
        }
    }
}
