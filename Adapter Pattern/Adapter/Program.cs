using System;
using System.Collections.Generic;

namespace Adapter
{
    class ThirdPartyDevelopers // Adaptee
    {
        public List<string> GetDevelopersList()
        {
            List<string> DevelopersList = new List<string>();

            DevelopersList.Add("Yasmin");
            DevelopersList.Add("Lamya");
            DevelopersList.Add("Abdulaziz");
            DevelopersList.Add("Layan");

            return DevelopersList;
        }
    }

    interface ITarget // Target
    {
        List<string> GetDevelopers();
    }

    class DevelopersAdapter : ThirdPartyDevelopers, ITarget // Adapter
    {
        public List<string> GetDevelopers()
        {
            return GetDevelopersList();
        }
    }

    class Client // Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of Developers:");

            ITarget adapter = new DevelopersAdapter();

            foreach (string developer in adapter.GetDevelopers())
            {
                Console.WriteLine(developer);
            }
            Console.ReadKey();
        }
    }
}
