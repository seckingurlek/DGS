using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected  IConfiguration Configuration { get; set; }
       



        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
   
            modelBuilder.Entity<AppUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Landlord>("Landlord")
                .HasValue<Tenant>("Tenant");

            // Landlord → Property (1:N)
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Landlord)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            // Deposit → Property (N:1)
            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Property)
                .WithMany(p => p.Deposits)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Deposit → Tenant (N:1)
            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Tenant)
                .WithMany(t => t.Deposits)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Deposit → Landlord (N:1)
            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Landlord)
                .WithMany(l => l.Deposits)
                .HasForeignKey(d =>d.LandlordId) 
                .OnDelete(DeleteBehavior.Restrict);

            // DepositRequest → Property (N:1)
            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Property)
                .WithMany()
                .HasForeignKey(dr => dr.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            // DepositRequest → Landlord (N:1)
            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Landlord)
                .WithMany(l => l.DepositRequests)
                .HasForeignKey(dr => dr.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            // DepositRequest → Tenant (N:1)
            modelBuilder.Entity<DepositRequest>()
                .HasOne(dr => dr.Tenant)
                .WithMany(t => t.DepositRequests)
                .HasForeignKey(dr => dr.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
