using System;

namespace designpatren3
{

    public interface ITarget
    {
        string CalculateFormula();
    }

    class Adaptee
    {
       
        public string CalculateFormula()
        {
            return "Third party tool formula calculation";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string CalculateFormula()
        {
            return $"This is '{this._adaptee.CalculateFormula()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.CalculateFormula());
        }
    }
}
