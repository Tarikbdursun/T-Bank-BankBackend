using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService<T> where T: User,IUser,new()
    {
        //Create, Read, Update, Delete
        IResult Add(T user);
        IResult Delete(T user);
        IResult Update(T user);
        IDataResult<T> GetById(int userId);
        T GetByMail(string email);
        IDataResult<List<T>> GetAll();
        List<OperationClaim> GetClaims(User user);
    }
}
