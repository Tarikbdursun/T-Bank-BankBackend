using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class EmployeeAuthManager : BaseAuthManager<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeAuthManager(IEmployeeService employeeService, ITokenHelper tokenHelper) : base(employeeService, tokenHelper)
        {
            _employeeService = employeeService;
            _tokenHelper = tokenHelper;
        }
        public override IDataResult<User> Register(IUserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            var employee = new Employee
            {
                Email = userForRegisterDto.Email,
                MobilePhoneNumber = userForRegisterDto.MobilePhoneNumber,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                //Deparment=userForRegisterDto.Department
            };
            _userService.Add(employee);
            return new SuccessDataResult<User>(employee, Messages.UserRegistered);
        }
    }
}
