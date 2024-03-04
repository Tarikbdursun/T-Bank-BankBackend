using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerAuthManager : BaseAuthManager<Customer>
    {
        ICustomerService _customerService;
        public CustomerAuthManager(ICustomerService customerService, ITokenHelper tokenHelper):base(customerService,tokenHelper)
        {
            _customerService = customerService;
            _tokenHelper=tokenHelper;
        }
        public override IDataResult<User> Register(IUserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var customer = new Customer
            {
                Email = userForRegisterDto.Email,
                MobilePhoneNumber = userForRegisterDto.MobilePhoneNumber,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(customer);
            return new SuccessDataResult<User>(customer, Messages.UserRegistered);
        }
    }
}
