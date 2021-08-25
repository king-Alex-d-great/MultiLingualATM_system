using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMCore.Interfaces;

namespace ATMCore
{
    class PidginUserInteractors : ILanguage
    {
        public void UserStatusMenu()
        {
            Console.WriteLine("If you dey use this service for the first time");
            Console.WriteLine("Press 1 to register\n");
            Console.WriteLine("If you don dey use am teytey");
            Console.WriteLine("Press 2 to Login\n");
        }
        public void collectFirstName() => Console.WriteLine("Type your firstname");
        public void collectLastName() => Console.WriteLine("Type your lastname");
        public void collectCVV()
        {
            Console.WriteLine("Abeg, Type your 3-digit cvv ");
            Console.WriteLine("---> The 3-digit number wey dey for the back of your ATM CARD");
        }
        public void CvvError() => Console.WriteLine("Your cvv must to get ONLY Three(3) digits");
        public void collectBVN() => Console.WriteLine("Abeg, Type your 8-digit bvn");
        public void collectBVNError() => Console.WriteLine("Your BVN must to get ONLY Eight(8) digits");

        public void collectPin() => Console.WriteLine("Abeg, Type your pin");

        public void PinError() => Console.WriteLine("Your pin must to get up to four(4) digits");

        public void AtmMainMenu(string name)
        {
            Console.WriteLine($"Hello {name} ,you dey welcome! ");
            Console.WriteLine();
            Console.WriteLine("Press 1 : Check how much dey your account \nPress 2 : Comot monry from your account \nPress 3 : Change Language\nPress 4 : Exit\n ");
        }
        
    }
    }
