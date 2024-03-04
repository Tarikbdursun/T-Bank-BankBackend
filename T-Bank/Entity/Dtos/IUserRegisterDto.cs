using Core.Entities;

namespace Entities.Dtos
{
    public interface IUserRegisterDto : IDto
    {
        string Email { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MobilePhoneNumber { get; set; }
        UserType UserType { get; }
    }
}
