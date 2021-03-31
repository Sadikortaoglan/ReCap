using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private ICarImageDal _carImageDal;
        public CarManager(ICarDal carDal, ICarImageDal carImageDal)
        {
            _carDal = carDal;
            _carImageDal = carImageDal;
        }
        
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }
        
        public IDataResult<Car> GetById(int carId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }
        
        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndColor(brandId, colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailById(carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarBrandandColor(int brandId, int colorId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetailByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == colorId));
        }


        //[SecuredOperation("Car.Update")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarPriceInvalid);
        }
    }
}
