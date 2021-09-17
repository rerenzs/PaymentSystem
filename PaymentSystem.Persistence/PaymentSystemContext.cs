using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

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

               base.OnModelCreating(modelBuilder);
            //seeder
            modelBuilder.Entity<Account>().HasData(
                DefaultAccounts.AccountList()
                );

            modelBuilder.Entity<Payment>().HasData(
                DefaultPayments.PaymentList()
                );
        }
    }
}
