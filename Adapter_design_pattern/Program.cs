using System;

namespace Adapter_design_pattern
{
    // The Target defines the domain-specific interface used by the client code.
    public interface IUKToSAAdapter
    {
        string ProvideElectricity();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    class SAPlugConnecter
    {
        public string GetElectricity()
        {
            return "Get Electricity.";
        }
    }

    // The UKToSAAdapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class UKToSAAdapter : IUKToSAAdapter
    {
        private readonly SAPlugConnecter _adaptee;

        public UKToSAAdapter(SAPlugConnecter adaptee)
        {
            this._adaptee = adaptee;
        }

        public string ProvideElectricity()
        {
            return $"This is '{this._adaptee.GetElectricity()}'";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SAPlugConnecter plugConnecter = new SAPlugConnecter();
            IUKToSAAdapter target = new UKToSAAdapter(plugConnecter);


            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with UKToSAAdapter client can call it's method.");

            Console.WriteLine(target.ProvideElectricity());

        }
    }
}