using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService<T> where T : User
    {
        //Login, Register
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(IUserRegisterDto userForRegisterDto, string password);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        //TODO alttaki satırı sil GetClaims
        IResult GetClaims();
    }
}
