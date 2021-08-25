using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMDb.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal  Bvn { get; set; }
        public int  Cvv { get; set; }
        public string  Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountNumber { get; set; } 
        public decimal AccountBalance { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool isActive { get; set; }
        [Column("LoginId")]
        public int LoginDetailId { get; set; }
        [ForeignKey(nameof(LoginDetailId))]
        public LoginDetail LoginDetail { get; set; }
    }
}
