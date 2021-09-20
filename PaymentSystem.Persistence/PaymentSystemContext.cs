using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Persistence.Seeds;
using System.Collections.Generic;

namespace PaymentSystem.Persistence
{
    public class PaymentSystemContext : IdentityDbContext<Account>
    {
        public PaymentSystemContext()
        {
        }
        public PaymentSystemContext(DbContextOptions<PaymentSystemContext> options) : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<Account>();

            base.OnModelCreating(modelBuilder);
            //seeder
            modelBuilder.Entity<Account>().HasData( 
                new List<Account>{
                    new Account
                    {
                        Name = "Peter Parker",
                        AccountNumber = 2123123,
                        Balance = 1200,
                        Email = "peter@mail.com",
                        NormalizedEmail = "PETER@MAIL.COM",
                        UserName = "peter@mail.com",
                        NormalizedUserName = "PETER@MAIL.COM",
                        PasswordHash = passwordHasher.HashPassword(null, "Password@1"),
                    },
                    new Account
                    {
                        Name = "John Doe",
                        AccountNumber = 65456453,
                        Balance = 2000,
                        Email = "john@mail.com",
                        NormalizedEmail = "JOHN@MAIL.COM",
                        UserName = "john@mail.com",
                        NormalizedUserName = "JOHN@MAIL.COM",
                        PasswordHash = passwordHasher.HashPassword(null, "Password@2"),
                    } 
                }
                );

            modelBuilder.Entity<Payment>().HasData(
                DefaultPayments.PaymentList()
                );
        }
    }
}
