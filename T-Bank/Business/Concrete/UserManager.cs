﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //public class UserManager : IUserService
    //{
    //    IUserDal _userDal;

    //    public UserManager(IUserDal userDal)
    //    {
    //        _userDal = userDal;
    //    }

    //    public IResult Add(User user)
    //    {
    //        _userDal.Add(user);
    //        return new SuccessResult();
    //    }

    //    public IResult Delete(User user)
    //    {
    //        _userDal.Delete(user);
    //        return new SuccessResult();
    //    }

    //    public IDataResult<List<User>> GetAll()
    //    {
    //        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    //    }

    //    public IDataResult<User> GetById(int userId)
    //    {
    //        return new SuccessDataResult<User>(_userDal.Get(x => x.ID == userId));
    //    }

    //    public User GetByMail(string email)
    //    {
    //        return _userDal.Get(x => x.Email == email);
    //    }

    //    public IResult Update(User user)
    //    {
    //        _userDal.Update(user);
    //        return new SuccessResult();
    //    }

    //    public List<OperationClaim> GetClaims(User user)
    //    {
    //        return _userDal.GetClaims(user);
    //    }
    //}
}
