using System;
using System.Collections.Generic;
using System.Text;

namespace ATMDb.Models
{
    public class LoginDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int CVV { get; set; }
    }
}
