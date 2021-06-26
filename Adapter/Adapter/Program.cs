using System;

namespace Adapter
{
    // محول للكهرباء يوصل ثلاجة تعمل على خط 110 بفيش كهربائي بخط 220 

    public interface ITarget // 220 v  
    {
        string GetRequest();
    }

    class Refrigerator // Refrigerator 110 v 
    {
        public string GetSpecificRequest()
        {
            return "Refrigerator 110 v ";
        }
    }


    class Adapterpower_Transformer : ITarget // Adapterpower 110 -> 220
    {
        private readonly Refrigerator _refrigerator;

        public Adapterpower_Transformer(Refrigerator refrigerator)
        {
            this._refrigerator = refrigerator;
        }

        public string GetRequest()
        {
            return $"This is '{this._refrigerator.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator = new Refrigerator();
            ITarget target = new Adapterpower_Transformer(refrigerator);

            Console.WriteLine(target.GetRequest());
        }
    }
}