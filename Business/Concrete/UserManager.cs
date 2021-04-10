using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        //[SecuredOperation("user.add,admin")]
        //[ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        //[SecuredOperation("user.update,admin")]
        //[ValidationAspect(typeof(UserValidator))]
        //[CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        //[SecuredOperation("user.delete,admin")]
        //[ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IResult UpdateInfo(User user)
        {
            var userToUpdate = GetById(user.Id).Data;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            Update(userToUpdate);
            return new SuccessResult();
        }

        //[CacheRemoveAspect("IUserService.Get")]
        //public IResult UpdateUserFindex(int userId)
        //{
        //    var userToUpdateFindex = _userDal.Get(u => u.UserId == userId);
        //    if (userToUpdateFindex.FindexPoint != 1900)
        //    {
        //        userToUpdateFindex.FindexPoint += 100;
        //        _userDal.Update(userToUpdateFindex);
        //        return new SuccessResult(Messages.EarnedFindex);
        //    }
        //    else
        //    {
        //        userToUpdateFindex.FindexPoint = 1900;
        //        return new SuccessResult(Messages.MaxFindex);
        //    }

        //}

        public IDataResult<User> GetUserFindexByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IResult UpdateUserFindex(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

