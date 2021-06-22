using System;

namespace AdapterHW
{
    public interface ITarget
    {
        string GetRequest();
    }

   
    class Target
    {
        public string GetOurTarget()
        {
            return "There You Go!";
        }
    }

    class Adapter : ITarget
    {
        private readonly Target ourTarget;

        public Adapter(Target adaptee)
        {
            this.ourTarget = adaptee;
        }

        public string GetRequest()
        {
            return $"Calling our target with incompatible interface ---> '{this.ourTarget.GetOurTarget()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Target adaptee = new Target();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine(target.GetRequest());
        }
    }
}
