using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMCore.Interfaces;
using ATMDb.Models;


namespace ATMCore
{
    class Authentication
    {
        static Account NewUser;        
        static int UserCount = 0;
        public static void Register(Register model)
        {
            //var ValidatedPassword = (model.PassWord, model.ConfirmPassword);
            try
            {
                NewUser = new Account
            {
                FirstName = $"{model.FirstName} ",
                LastName = $"{model.LastName}",
                Bvn = model.BVN,
                Cvv = model.CVV,
                Password = model.Password,
                 AccountBalance = model.AccountBalance,
                isActive = true,
                AccountNumber = 0,
                TimeStamp = DateTime.Now,
                LoginDetail = new LoginDetail {CVV = model.CVV, Name= model.FirstName, Password= model.Password}
            };
            var dbcontext =Atm.DbContext();
            dbcontext.Accounts.Add(NewUser);
            dbcontext.SaveChanges();
            Console.WriteLine($"Congratulations {NewUser.FirstName}, your registration was successfull\n");
           
            Console.WriteLine();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        public static void Login()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your CVV");
            var UserAcclaimedCVV = Convert.ToInt32(Console.ReadLine());
            if (UserAcclaimedCVV.ToString().Length == 0)
            {
                Validator.ErrorMenu("Username");
            }           
            Console.WriteLine("Enter your Password");
            var UserAcclaimedPassword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(UserAcclaimedPassword))
            {
               Validator.ErrorMenu("Password");
            }           
            UserAcclaimedPassword = UserAcclaimedPassword.Trim().ToLower();
            var isValidated = Validator.validateLoginDetails(UserAcclaimedCVV, UserAcclaimedPassword);
            if (isValidated)
            {
               var dbcontext = Atm.DbContext();
               Atm.MainMenu(UserAcclaimedCVV, UserAcclaimedPassword, ref dbcontext);
            }
            else
            {
                ILanguage.DisplayContinueOrExitOption();
            }
        }        
    }
}
