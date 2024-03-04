using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public interface IUser : IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string MobilePhoneNumber { get; set; }
        byte[] PasswordSalt { get; set; }
        byte[] PasswordHash { get; set; }
        bool Status { get; set; }
    }
}
