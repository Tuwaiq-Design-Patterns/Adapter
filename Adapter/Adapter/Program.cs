using System;

namespace Adapter
{
    public interface IlaptopCharger
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


    class Plug : IlaptopCharger
    {
        private readonly Server server;

        public Plug(Server server)
        {
            this.server = server;
        }

        public string GetRequest()
        {
            return $"This is '{this.server.PostRequest()}'";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Server webServices = new Server();
            IlaptopCharger british = new Plug(webServices);
          

            Console.WriteLine("Server interface is incompatible with the client.");
            Console.WriteLine("But with adapter convert to wall charger");

            Console.WriteLine(british.GetRequest());
          
        }
    }
}