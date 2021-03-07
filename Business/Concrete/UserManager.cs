using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName != null && user.LastName != null && user.Email != null && user.Password != null)
            {
                _userDal.Add(user);
                Console.WriteLine(user.UserId + " numaralı " + user.FirstName + " " + user.LastName + " isimli kullanıcı bilgisi sisteme eklendi.");
                return new SuccessResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Delete(int userId)
        {
            try
            {
                var userBul = _userDal.Get(u => u.UserId == userId);
                if (userBul != null)
                {
                    _userDal.Delete(userBul);
                    return new SuccessResult(Messages.UserDeleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            Console.WriteLine("Sistemde yer alan " + user.UserId + " numaralı " + user.FirstName + " " + user.LastName + " Kullanıcı bilgisi güncellendi.");
            return new Result(true, Messages.CustomerUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

    }
}
