using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCore
{
    class Application
    {
        static StringBuilder _menu = new StringBuilder(); 
        
        public static void Run ()
        {
            ShowIntroductoryMessage();
        }
        public static void ShowIntroductoryMessage()
        {
            string SelectedLanguageOption;
            int LanguageSelectionCount = 0;
            Console.ForegroundColor = ConsoleColor.White;
            _menu.Append("Welcome to cATM");
            Console.WriteLine("-----> Zenith of all Cardless Banking");
            Console.WriteLine(); 

            while (true && LanguageSelectionCount < 3)
            {               
                Console.WriteLine("Please Select a language");
                Console.WriteLine("1:  English");
                Console.WriteLine("2:  Pidgin");
                // Console.WriteLine("3:   Spanish");
                Console.WriteLine();
                SelectedLanguageOption = Console.ReadLine();
                if (SelectedLanguageOption == "1")
                {
                    var EnglishAtm = new Atm(new EnglishUserInteractors());
                    EnglishAtm.Run();
                    break;
                }
                else if (SelectedLanguageOption == "2")
                {
                    var PidginAtm = new Atm(new PidginUserInteractors());
                    PidginAtm.Run();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You did not enter a correct Input");
                    Console.WriteLine($" \n\nYou have {2 - LanguageSelectionCount} more chance(s)");
                    LanguageSelectionCount++;
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }
            }

            if (LanguageSelectionCount > 2)
                Console.WriteLine("your Chances have been exhausted ,\n\nThis cATM will now delay for 30 minutes before next Use ");
            //return SelectedLanguageOption;
        }        
    }    
               

                
   
}
