using System;

namespace Adapter_design_pattern
{
    public interface IUKToSAAdapter
    {
        string ProvideElectricity();
    }

    class SAPlugConnecter
    {
        public string GetElectricity()
        {
            return "Get Electricity.";
        }
    }

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