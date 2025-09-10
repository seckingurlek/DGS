using Domain.SecurityEntities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration)
            : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DepositRequest> DepositRequests { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ TPH Discriminator
            modelBuilder.Entity<AppUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Landlord>("Landlord")
                .HasValue<Tenant>("Tenant");

            // ✅ Unique Indexler
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.IdentityNumber)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // ✅ Property Relations
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Landlord)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
                .Property(p => p.DepositAmount)
                .HasColumnType("decimal(18,2)");

            // ✅ Deposit Relations
            modelBuilder.Entity<Deposit>()
                .Property(d => d.DepositAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Property)
                .WithMany(p => p.Deposits)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Tenant)
                .WithMany(t => t.Deposits)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Landlord)
                .WithMany(l => l.Deposits)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ DepositRequest Relations
            modelBuilder.Entity<DepositRequest>()
                .Property(dr => dr.DepositAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Property)
                .WithMany()
                .HasForeignKey(dr => dr.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Landlord)
                .WithMany(l => l.DepositRequests)
                .HasForeignKey(dr => dr.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Tenant)
                .WithMany(t => t.DepositRequests)
                .HasForeignKey(dr => dr.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ UserOperationClaim Relations
            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(uoc => uoc.User)
                .WithMany(u => u.UserOperationClaims)
                .HasForeignKey(uoc => uoc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(uoc => uoc.OperationClaim)
                .WithMany()
                .HasForeignKey(uoc => uoc.OperationClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ RefreshToken Relations
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // =============================
            // 🔹 Seed Data
            // =============================
            var landlordId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var tenantId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var propertyId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var depositRequestId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var claimId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var userOperationClaimId = Guid.Parse("66666666-6666-6666-6666-666666666666");

            // Dummy hash & salt
            var passwordHash = new byte[] { 1, 2, 3 };
            var passwordSalt = new byte[] { 4, 5, 6 };

            modelBuilder.Entity<Landlord>().HasData(new Landlord
            {
                Id = landlordId,
                FirstName = "Ali",
                LastName = "Yılmaz",
                Email = "ali@test.com",
                PhoneNumber = "05551234567",
                IdentityNumber = "12345678901",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                EmailConfirmed = true
            });

            modelBuilder.Entity<Tenant>().HasData(new Tenant
            {
                Id = tenantId,
                FirstName = "Ayşe",
                LastName = "Demir",
                Email = "ayse@test.com",
                PhoneNumber = "05559876543",
                IdentityNumber = "10987654321",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                EmailConfirmed = true
            });

            modelBuilder.Entity<Property>().HasData(new Property
            {
                Id = propertyId,
                LandlordId = landlordId,
                Title = "Deneme Ev",
                Address = "Test Mah. 123",
                DepositAmount = 1000
            });

            modelBuilder.Entity<DepositRequest>().HasData(new DepositRequest
            {
                Id = depositRequestId,
                TenantId = tenantId,
                LandlordId = landlordId,
                PropertyId = propertyId,
                DepositAmount = 1000,
                Status = DepositRequestStatus.Pending,
                IsAccepted = null,
                TenantIdentityNumber = "10987654321",
                TenantEmail = "ayse@test.com",
                TenantPhone = "05551234567",
                RentalStartDate = DateTime.UtcNow.Date,
                RentalEndDate = DateTime.UtcNow.AddMonths(1).Date,
                RequestDate = DateTime.UtcNow
            });

            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim
            {
                Id = claimId,
                Name = "Admin"
            });

            modelBuilder.Entity<UserOperationClaim>().HasData(new UserOperationClaim
            {
                Id = userOperationClaimId,
                UserId = landlordId,
                OperationClaimId = claimId
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
