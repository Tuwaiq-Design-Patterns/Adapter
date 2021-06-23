using System;

namespace Adapter
{
    public interface ILogin
    {
        public void Login(string username, string password);
    }
    public class Facebook : ILogin
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("login by Facebook .." + " and username is " + username);
        }

    }
    public class Google : ILogin 
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("login by Google .." + " and username is " + username);
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
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Facebook facebook = new Facebook();
            Google google = new Google();

            var loginManagerFacebook = new LoginManger(facebook);
            var loginManagerGoogle = new LoginManger(google);

            Console.WriteLine("You need Login by  ?\n 1-Facebook \n 2-Google ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    loginManagerFacebook.Login("Taif", "198djndd");
                    break;
                case 2:
                    loginManagerGoogle.Login("Rahaf","shsg799");
                    break;
                default:
                    Console.WriteLine("Invalid choice..");
                    break;
            }
        }
    }
}
