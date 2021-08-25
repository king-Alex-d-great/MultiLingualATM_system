using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCore
{
    class Register
    {
        public decimal BVN { get; set; }
        public int CVV { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountBalance { get; set; }

    }
}
