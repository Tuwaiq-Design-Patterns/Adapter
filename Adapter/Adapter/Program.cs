using System;

namespace Adapter
{
    public interface ILogin
    {

        public void Login(string username, string password);
    }
    public class Twitter : ILogin
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("login by Twitter ..\nWith username : " + username + "\nPassword : " + password);
        }

    }
    public class Printrest : ILogin //Login by printrest  app
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("login by Printrest ..\nWith username : " + username + "\nPassword : " + password);
        }
    }

    public class LoginManger
    {
        private readonly ILogin loginService;
        public LoginManger(ILogin loginService)
        {
            this.loginService = loginService;

        }
        public void Login(string username, string password)
        {
            this.loginService.Login(username, password);
        }

        class Program
        {
            static void Main(string[] args)
            {//user need to login and the adapter adapts according to the way you log in either twitter or printrest 


                Twitter twitter = new Twitter();
                Printrest printrest = new Printrest();

                var loginManagert = new LoginManger(twitter);
                var loginManagerL = new LoginManger(printrest);



                Console.WriteLine("You need Login by  ?\n 1-Twitter \n 2-Printrest ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        loginManagert.Login("Taif", "XXX");
                        break;

                    case 2:
                        loginManagerL.Login("Rawabe", "XXX");
                        break;

                    default:
                        Console.WriteLine("Invalid choice..");
                        break;
                }

            }
        }
    }
}

