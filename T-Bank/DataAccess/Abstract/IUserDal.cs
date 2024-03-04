using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal<T> :IEntityRepository<T> where T : class,IEntity,new()
    {
        List<OperationClaim> GetClaims(User t);
    }
}
