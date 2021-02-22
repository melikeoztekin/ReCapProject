﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                Console.WriteLine(color.ColorId + " numaralı " + color.ColorName + " renk bilgisi sisteme eklendi.");
                return new SuccessResult(Messages.Added);
            }
            else if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(int colorId)
        {
            try
            {
                var colorBul = _colorDal.Get(k => k.ColorId == colorId);
                if (colorBul != null)
                {
                    _colorDal.Delete(colorBul);
                    return new SuccessResult(Messages.Deleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.IdError);
            }

        }
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<List<Color>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("No. " + color.ColorId + " " + color.ColorName + " colored vehicle information  in the system has been updated.");
            return new Result(true, Messages.Updated);
        }

        
    }
}
