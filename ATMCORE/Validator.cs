using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATMCore.Interfaces;

namespace ATMCore
{
    class Validator
    {
        public static void ErrorMenu(string name)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nError Alert");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Your {name} cannot be empty\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Please Input your {name}\n");
                var Input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    break;
                }
            }
        }

        public static void PidginErrorMenu(string name)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nError Alert");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Your {name} no fit dey empty\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Write your {name}\n");
                var Input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    break;
                }
            }
        }

        public static bool validateLoginDetails(int cvv, string password)
        {
            var isValidated = false;
            var dbcontext = Atm.DbContext();
            
            var result = dbcontext.LoginDetails.Where(x => x.CVV.Equals(cvv)).Where(y => y.Password.Equals(password));
           
            foreach(var item in result)
            {
                Console.WriteLine(item.Id);
            }

            if (result.Count() == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your username or password is Incorrect\nor you aren't registered to this service\n");
            }
            else
            {
                isValidated = true;
            }
            return isValidated;
        }

        public bool ValidateName(string Input)
        {
            var isStringValid = false;
            var pattern = @"[a-zA-Z]+";
            var regex = new Regex(pattern);
            var match = regex.Match(Input);
            if (match.Success)
            {
                isStringValid = true;
            }
            return isStringValid;
        }
    }
}
