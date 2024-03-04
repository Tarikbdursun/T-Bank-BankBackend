using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerUserDal _customerDal;

        public CustomerManager(ICustomerUserDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer user)
        {
            _customerDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(Customer user)
        {
            _customerDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.ID == userId));
        }

        public Customer GetByMail(string email)
        {
            return _customerDal.Get(x => x.Email == email);
        }

        public IResult Update(Customer user)
        {
            _customerDal.Update(user);
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _customerDal.GetClaims(user);
        }
    }
}
