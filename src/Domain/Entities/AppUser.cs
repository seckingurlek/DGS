using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class AppUser : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; } // İstersen tamamen kaldırıp sadece Hash/Salt bırakabiliriz
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? Address { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; } 

    }
}
