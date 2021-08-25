using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMCore.Interfaces;
using ATMDb.Models;

namespace ATMCore
{
    class Atm
    {
        protected static ILanguage _language;
        static AtmContext _dbContext = new AtmContext();
       
        public Atm(ILanguage language)
        {
            _language = language;
            
        }
        public void Run ()
        {
            UserstatusMenu();
        }
        public static void MainMenu(int cvv, string password,ref AtmContext dbcontext)
        {
           // Console.WriteLine($"Hello {name} ,You are welcome! ");
            Console.WriteLine();
            Console.WriteLine("Press 1 : Check your balance \nPress 2 : Withdraw cash \nPress 3 : Change Language\nPress 4 : Exit\n ");
            switch (Console.ReadLine())
            {
                case "1":
                    CheckBalance(cvv, password);
                    ILanguage.DisplayContinueOrExitOption();                   
                    break;
                case "2":
                    WithdrawCash(cvv, password);
                    ILanguage.DisplayContinueOrExitOption();
                    break;
                case "3":
                    ChangeLanguage();
                    Console.WriteLine("Coming soon");
                    ILanguage.DisplayContinueOrExitOption();
                    break;
                case "4":
                    Console.WriteLine("Thank you for Using this service");
                    break;
                default:
                    {
                        ILanguage.DisplayContinueOrExitOption();
                        break;
                    }
            }
        }        
        protected static void CheckBalance(int cvv, string password)
        {
            var result = _dbContext.Accounts.Where(x => x.Cvv.Equals(cvv));

            foreach (var item in result)
            {
                Console.WriteLine((item.AccountBalance).ToString());
            }
        }
        protected static void WithdrawCash(int cvv, string password)
        {
            var result = _dbContext.Accounts.FirstOrDefault(a => a.Cvv == cvv);  
           
            // var  = database.Where(a => a.Value.FullName.Equals(name)).Where(b => b.Value.setPassword.Equals(password)).Select(a => a.Value.AccountBalance);
            Console.Clear();
            Console.WriteLine($"Your Account balance is {result.AccountBalance} USD");
            Console.WriteLine("How much will you like to withdraw");
            int UserReply = Convert.ToInt32(Console.ReadLine());

            if (UserReply < result.AccountBalance)
            {
                result.AccountBalance -= UserReply;
                //_dbContext.Accounts.Update(result as Account);
                _dbContext.SaveChanges();
                
                Console.WriteLine("\nIn what denominations will you like your cash to be \n1. 1000 Naira\n2. 500 Naira");
                int UserReply1 = Convert.ToInt32(Console.ReadLine());
                if (UserReply1 == 1)
                {
                    Console.WriteLine("Collect your cash\n");// CurrrencyNoteCount //ADD CoLOR
                    Console.WriteLine($"{UserReply / 1000} notes of 1000 Naira , amounting to {UserReply} \n");
                }
                if (UserReply1 == 2)
                {
                    Console.WriteLine("Collect your cash\n");// CurrrencyNoteCount 
                    Console.WriteLine($"There are {UserReply / 500} notes of 500 Naira , amounting to {UserReply } \n");
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        protected static void ChangeLanguage()
        {           
            Authentication.Login();
        }

       public void UserstatusMenu()
        {
            _language.UserStatusMenu();
            
            var UserStatus = Console.ReadLine();
            if (UserStatus == "1")
            {
                var Userdata = CollectData(); //collectinfo will return formdata                
                Authentication.Register(Userdata);
                ILanguage.DisplayContinueOrExitOption();
            }
            if(UserStatus == "2")
            {
                Authentication.Login();
            }
            else
            {

            }
        }
        public static AtmContext DbContext ()
        {
            return _dbContext;
        }
        public static Register CollectData()
        {
            Random RandomNumber = new Random();
            Register FormData;
            var menu = new StringBuilder();

            int cvv;
            string Firstname;
            string Lastname;
            decimal bvn;
            string password;

            menu.Append("Enter your details:");
            Console.WriteLine(menu.ToString());
            _language.collectFirstName();
          
            Firstname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                Validator.ErrorMenu("Firstname");
            }
            _language.collectLastName();
           
            Lastname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Lastname))
            {
                Validator.ErrorMenu("Lastname");
            }
        enterCvv:
            _language.collectCVV();           
           
            try
            {
                cvv = Convert.ToInt32(Console.ReadLine());
                if (cvv.ToString().Length == 0)
                {
                    Validator.ErrorMenu("CVV");
                }
                if (cvv.ToString().Length != 3)
                {
                    Console.WriteLine();_language.CvvError();
                    goto enterCvv;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto enterCvv;
            }
        EnterBvn:
            
            _language.collectBVN();
            try
            {
                bvn = Convert.ToDecimal(Console.ReadLine());
                if (bvn.ToString().Length != 8)
                {
                    Console.WriteLine();
                    _language.collectBVNError();                    
                    goto EnterBvn;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto EnterBvn;
            }
        EnterPassword:
            //Console.WriteLine("Abeg, Type your pin");
            _language.collectPin();
            password = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(password))
            {
                Validator.ErrorMenu("Pin");
            }
            if (password.Length < 4)
            {
                Console.WriteLine();
                _language.PinError();
                //Console.WriteLine("Your pin must to get up to four(4) digits");
                goto EnterPassword;
            }

            FormData = new Register
            {
                FirstName = Firstname,
                LastName = Lastname,
                BVN = bvn,
                CVV = cvv,
                Password = password,
                AccountBalance = (int)RandomNumber.Next(150000, 2000000),
            };

            return FormData;

        }

        
        
    }
}
