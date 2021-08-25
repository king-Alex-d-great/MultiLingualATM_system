using System;
using System.Collections.Generic;
using System.Text;
using ATMCore.DAL;
using Microsoft.EntityFrameworkCore;

namespace ATMDb.Models
{
    public class AtmContext : DbContext
    {
        //Not adding this default constructor creatd an error
        //Build will fail if any project in this solution has an erroe 
        public AtmContext() { }
        public AtmContext(DbContextOptions<AtmContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=AtmDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<LoginDetail> LoginDetails { get; set; }
    }
}
