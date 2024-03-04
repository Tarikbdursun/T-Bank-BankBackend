using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Core.Entities;

namespace DataAccess.Concrete
{
    public abstract class EfUserDal<T> : EfEntityRepositoryBase<T,BankDbContext>,IUserDal<T> where T : class,IEntity,new()
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context= new BankDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim
                             {
                                 ID = operationClaim.ID,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
