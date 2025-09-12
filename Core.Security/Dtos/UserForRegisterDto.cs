using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Dtos
{
    public class UserForRegisterDto
    {
        public string Role { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
