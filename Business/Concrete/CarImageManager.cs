using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstant.ImagesPath).Message;
            carImage.ImageUploadDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstant.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstant.ImagesPath + carImage.ImagePath, PathConstant.ImagesPath).Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result < 0)
            {
                return new ErrorResult(Messages.CarImageDoesntExists);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, ImageUploadDate = DateTime.Now, ImagePath = "default.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
