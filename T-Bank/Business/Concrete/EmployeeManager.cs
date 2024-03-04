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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeUserDal _employeeDal;

        public EmployeeManager(IEmployeeUserDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IResult Add(Employee user)
        {
            _employeeDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(Employee user)
        {
            _employeeDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
        }

        public IDataResult<Employee> GetById(int userId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.ID == userId));
        }

        public Employee GetByMail(string email)
        {
            return _employeeDal.Get(x => x.Email == email);
        }

        public IResult Update(Employee user)
        {
            _employeeDal.Update(user);
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _employeeDal.GetClaims(user);
        }
    }
}
