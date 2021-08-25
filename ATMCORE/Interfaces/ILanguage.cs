using System;


namespace ATMCore.Interfaces
{
    interface ILanguage
    {
        void UserStatusMenu();
        public void collectFirstName();
        public void collectLastName();
        public void collectCVV();
        public void CvvError();
        public void collectBVN();
        public void collectBVNError();
        public void collectPin();
        public void PinError();
        public void AtmMainMenu(string name);
        static void DisplayContinueOrExitOption()//interface function.....dis function soud be able to redirect you to loin or exit //redirection
        {
            Console.WriteLine("I want to \nPress 1: Continue\nPress 2: Register new user \nPress Any Other key: Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    Authentication.Login();
                    break;
                case "2":
                    var Userdata = Atm.CollectData();
                    Authentication.Register(Userdata);
                    DisplayContinueOrExitOption();
                    break;                    
                default:
                    Console.WriteLine("Thank you for Using this service");
                    break;
            };
        }
    }
}
