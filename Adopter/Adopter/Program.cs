using System;

namespace Adopter
{
    public interface ITarget
    {
        string GetImage();
    }
    
    class Adaptee
    {
        public string GetSpecificImage()
        {
            return "The Image";
        }
    }
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetImage()
        {
            return $"The image is here =>'{this._adaptee.GetSpecificImage()}'";
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

            Console.WriteLine(target.GetImage());
        }
    }
}