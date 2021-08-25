using System;
using System.Collections.Generic;
using System.Text;
using ATMCore.Interfaces;

namespace ATMCore
{
    class EnglishUserInteractors : ILanguage
    {  
        public void UserStatusMenu()
        {
            Console.WriteLine("If you are a first time user of this service  ");
            Console.WriteLine("Press 1 to register\n");
            Console.WriteLine("If you are an existing user of this service ");
            Console.WriteLine("Press 2 to Login\n");
        }
        public void collectFirstName() => Console.WriteLine("Enter your firstname");
        public void collectLastName() => Console.WriteLine("Enter your lastname");
        public void collectCVV()
        {
            Console.WriteLine("Enter your 3-digit CVV ");
            Console.WriteLine("---> The 3-digit number at the back of your ATM CARD");
        }
        public void CvvError () =>  Console.WriteLine("Your cvv must have ONLY Three(3) digits");
        public void collectBVN () => Console.WriteLine("Enter your 8-digit BVN");
        public void collectBVNError() => Console.WriteLine("Your BVN must have ONLY Eight(8) digits");

        public void collectPin () => Console.WriteLine("Enter a pin");
                
        public void PinError () =>Console.WriteLine("Your pin must have up to four(4) digits");

        public void AtmMainMenu(string name)
        {
            Console.WriteLine($"Hello {name} ,You are welcome! ");
            Console.WriteLine();
            Console.WriteLine("Press 1 : Check your balance \nPress 2 : Withdraw cash \nPress 3 : Change Language\nPress 4 : Exit\n ");
        }     
    }
}
