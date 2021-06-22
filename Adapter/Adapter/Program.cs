using System;

namespace Adapter
{

        public interface ITarget
        {
            string GetRequest();
        }

        class Adaptee
        {
            public string GetEmployeeRequest()
            {
                return "44, Albandry, Developer ";
            }
        }
        class Adapter : ITarget
        {
            private readonly Adaptee HRSystem;

            public Adapter(Adaptee adaptee)
            {
                this.HRSystem = adaptee;
            }

            public string GetRequest()
            {
                return $"This is '{this.HRSystem.GetEmployeeRequest()}'";
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("HR system interface (Adaptee) is incompatible with the ThirdPartyBillingSystem (client).");
            Console.WriteLine("But with EmployeeAdapter ThirdPartyBillingSystem can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }
}
