using System;

namespace Adapter
{
    public interface IwebRequest
    {
        string GetRequest();
    }

    class Server
    {
        public string PostRequest()
        {
            return "Post request ";
        }
    }

 
    class Adapter : IwebRequest
    {
        private readonly Server _adaptee;

        public Adapter(Server adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.PostRequest()}'";
        }
    }


class Program
    {
        static void Main(string[] args)
        {
        Server webServices = new Server();
        IwebRequest target = new Adapter(webServices);

        Console.WriteLine("Server interface is incompatible with the client.");
        Console.WriteLine("But with adapter convert to json");

        Console.WriteLine(target.GetRequest());
    }
    }
}
