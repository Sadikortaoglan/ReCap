using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(filter => filter.Id == Id));
        }

        public IDataResult<List<CarDetailDto>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result.Message);
            }

            return new SuccessDataResult<List<CarDetailDto>>(CheckIfCarImageNull(carId).Message);
        }

        private IResult CheckIfCarImageNull(int carId)
        {
            {
                try
                {
                    string path = @"\uploads\default.jpg";

                    var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

                    if (!result)
                    {
                        List<CarImage> carImage = new List<CarImage>();

                        carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });

                        return new SuccessDataResult<List<CarImage>>(carImage);
                    }
                }
                catch (Exception exception)
                {

                    return new ErrorDataResult<List<CarImage>>(exception.Message);
                }

                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int carImageCarId)
        {
            var carImageCount = _carImageDal.GetAll(filter => filter.CarId == carImageCarId).Count;
            if (carImageCount >= 4)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
    }
}
