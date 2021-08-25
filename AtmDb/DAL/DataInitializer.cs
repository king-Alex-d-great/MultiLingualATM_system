using System;
using System.Collections.Generic;
using System.Text;
using ATMDb.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMCore.DAL
{
    static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var account = new List<Account>()
            {
               new Account {
                   Id= 1,
                   AccountBalance= 1234453636,
                   Cvv=123,
                   FirstName="Alex",
                   LastName="Ogubuike",
                   Bvn = 12345678,
                   AccountNumber=0760015555,
                   isActive=true, Password= "1234",
                   TimeStamp= DateTime.Now,
                   LoginDetailId = 1
                   }             

            };
            var LoginDetail = new LoginDetail { Id = 1, Password = "1234", Name = "Alex", CVV=123  };
            modelBuilder.Entity<LoginDetail>().HasData(LoginDetail);
            modelBuilder.Entity<Account>().HasData(account);
        }
    }
}
