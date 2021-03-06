using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
   public interface ICarImageService
   {
       IDataResult<List<CarImage>> GetAll();
       IDataResult<CarImage> Get(int Id);
       IDataResult<List<CarDetailDto>> GetByCarId(int carId);
       IResult Add(IFormFile file, CarImage carImage);
       IResult Update(IFormFile file, CarImage carImage);
       IResult Delete(CarImage carImage);

    }
}
