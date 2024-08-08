using BankingControlPanel.Application.Common.Interfaces;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.ValueObjects;
using BankingControlPanel.Infrastructure.Persistence.Sql.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(c => c.PersonalId)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(c => c.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(c => c.Sex)
                    .IsRequired();

                // Configure the address as owned type
                entity.OwnsOne(c => c.Address, a =>
                {
                    a.Property(ad => ad.Country).HasMaxLength(50);
                    a.Property(ad => ad.City).HasMaxLength(50);
                    a.Property(ad => ad.Street).HasMaxLength(100);
                    a.Property(ad => ad.ZipCode).HasMaxLength(10);
                });

                // Configure the relationship between Client and Account
                entity.HasMany(c => c.Accounts)
                    .WithOne()
                    .HasForeignKey(a => a.ClientId)
                    .IsRequired();
            });

            // Configuring Account entity
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(a => a.AccountType)
                    .IsRequired();
            });
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role (new Guid(DefaultRoles.AdminRoleId),"Admin","Admin"),
                new Role (new Guid(DefaultRoles.UserRoleId),"User","User")
            );

            // Seeding Users

            modelBuilder.Entity<User>().HasData(
                new User("admin","admin@test.com", DefaultUserPasswords.AdminPasswordHash,"Admin","Admin",new Guid(DefaultRoles.AdminRoleId))
                ,
                new User("user","user@test.com", DefaultUserPasswords.UserPasswordHash,"User","User",new Guid(DefaultRoles.UserRoleId))
            );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}

