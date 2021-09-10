﻿using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence
{
    public class PaymentSystemContext : DbContext
    {
        public PaymentSystemContext()
        {
        }

        public PaymentSystemContext(DbContextOptions<PaymentSystemContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VJNVJ6K;Database=PaymentSystem;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Payment>().HasKey(p => new
            //{
            //    p.AccountID
            //});
            modelBuilder.Entity<Account>().HasData(
                DefaultAccounts.AccountList()
                );

            modelBuilder.Entity<Payment>().HasData(
                DefaultPayments.PaymentList()
                );
        }
    }
}
