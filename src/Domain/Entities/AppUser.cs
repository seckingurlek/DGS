using Domain.Entities;
using Domain.SecurityEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public  class AppUser : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        public AppUser()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
        }
        public AppUser(Guid id, string email, string firstName, string lastName, string identityNumber, string phoneNumber, byte[] passwordSalt, byte[] passwordHash, bool emailConfirmed, bool status, string? address)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            PhoneNumber = phoneNumber;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            EmailConfirmed = emailConfirmed;
            Address = address;

        }
    }
}
