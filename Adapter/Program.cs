using System;
using System.Collections.Generic;

namespace Adapter
{


    class Printer
    {
        public void Print(string S)
        {
            Console.WriteLine(S);
        }
    }

    public interface IconvertIntToString
    {
        void IhaveInt(int number);
    }
    class Adapter : IconvertIntToString
    {
        private readonly Printer _adaptee;
        public void IhaveInt(int number)
        {

            string msg = number.ToString();

              Console.WriteLine(msg.GetType());
        }
        public Adapter(Printer adaptee)
        {
            this._adaptee = adaptee;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            IconvertIntToString converter = new Adapter(printer);
            int num = 55;
            converter.IhaveInt(num);
        }
    }
}
