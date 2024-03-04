using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //public class AuthManager : IAuthService
    //{
    //    IEmployeeService _employeeService;
    //    ICustomerService _customerService;
    //    ITokenHelper _tokenHelper;

    //    public AuthManager(IEmployeeService userService, ICustomerService customerService ,ITokenHelper tokenHelper)
    //    {
    //        _employeeService = userService;
    //        _customerService = customerService;
    //        _tokenHelper = tokenHelper;
    //    }

    //    public IDataResult<User> Register(CustomerForRegisterDto userForRegisterDto, string password)
    //    {
    //        byte[] passwordHash, passwordSalt;
    //        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
    //        var customer = new Customer
    //        {
    //            Email = userForRegisterDto.Email,
    //            MobilePhoneNumber=userForRegisterDto.MobilePhoneNumber,
    //            FirstName=userForRegisterDto.FirstName,
    //            LastName=userForRegisterDto.LastName,
    //            PasswordHash = passwordHash,
    //            PasswordSalt = passwordSalt,
    //            Status = true
    //        };
    //        _customerService.Add(customer);
    //        return new SuccessDataResult<User>(customer, Messages.UserRegistered);
    //    }

    //    public IDataResult<User> Register(EmployeeForRegisterDto employeeForRegisterDto, string password)
    //    {
    //        byte[] passwordHash, passwordSalt;
    //        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
    //        var employee = new Employee
    //        {
    //            Email = employeeForRegisterDto.Email,
    //            MobilePhoneNumber = employeeForRegisterDto.MobilePhoneNumber,
    //            FirstName = employeeForRegisterDto.FirstName,
    //            LastName = employeeForRegisterDto.LastName,
    //            PasswordHash = passwordHash,
    //            PasswordSalt = passwordSalt,
    //            Status = true,
    //            Deparment=employeeForRegisterDto.Department
    //        };
    //        _employeeService.Add(employee);
    //        return new SuccessDataResult<User>(employee, Messages.UserRegistered);
    //    }

    //    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    //    {
    //        User userToCheck = _employeeService.GetByMail(userForLoginDto.Email);
    //        if (userToCheck == null)
    //        {
    //            return new ErrorDataResult<User>(Messages.UserNotFound);
    //        }
            
    //        if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
    //        {
    //            return new ErrorDataResult<User>(Messages.PasswordError);
    //        }

    //        return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
    //    }


    //    public IResult UserExists(string email)
    //    {
    //        if (_employeeService.GetByMail(email)!=null)
    //        {
    //            return new ErrorResult(Messages.UserAlreadyExists);
    //        }

    //        return new SuccessResult();
    //    }

    //    public IDataResult<AccessToken> CreateAccessToken(User user)
    //    {
    //        var claims = _employeeService.GetClaims(user);
    //        var accessToken = _tokenHelper.CreateToken(user, claims);
    //        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    //    }

    //    public IResult GetClaims()
    //    {
    //        return _employeeService.GetAll();
    //    }
    //}
}
