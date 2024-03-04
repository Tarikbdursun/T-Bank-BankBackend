using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CustomerForRegisterDto:IUserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public UserType UserType => UserType.Customer;
    }
}
