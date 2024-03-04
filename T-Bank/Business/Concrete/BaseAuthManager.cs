using Business.Abstract;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;

namespace Business.Concrete
{
    public abstract class BaseAuthManager<T> : IAuthService<T> where T: User,IUser,new()
    {
        protected IUserService<T> _userService;
        protected ITokenHelper _tokenHelper;

        public BaseAuthManager(IUserService<T> userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public abstract IDataResult<User> Register(IUserRegisterDto userForRegisterDto, string password);
        //{
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        //    var customer = new Customer
        //    {
        //        Email = userForRegisterDto.Email,
        //        MobilePhoneNumber = userForRegisterDto.MobilePhoneNumber,
        //        FirstName = userForRegisterDto.FirstName,
        //        LastName = userForRegisterDto.LastName,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        Status = true
        //    };
        //    _customerService.Add(customer);
        //    return new SuccessDataResult<User>(customer, Messages.UserRegistered);
        //}

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            User userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }


        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult GetClaims()
        {
            return _userService.GetAll();
        }
    }
}
