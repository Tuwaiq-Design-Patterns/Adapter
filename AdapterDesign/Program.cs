using System;
using System.Collections.Generic;

namespace AdapterDesign
{
    // print method only receives string
    // client want to print a list 
    // adapter helps the client print the list
    public interface IPrintList
    {
        void IhaveList(List<string> list);
    }

    class PrintMethod
    {
        public void Print(string S)
        {
            Console.WriteLine(S);
        }
    }

    class Adapter : IPrintList
    {
        private readonly PrintMethod _adaptee;
        public void IhaveList(List<string> list)
        {
            foreach (var item in list)
            {
                _adaptee.Print(item);
            }

        }

        public Adapter(PrintMethod adaptee)
        {
            this._adaptee = adaptee;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrintMethod printMethod = new PrintMethod();
            IPrintList ListPrinter = new Adapter(printMethod);

            ListPrinter.IhaveList(new List<string>() { "Meshal", "Another Meshal" });
        }
    }

    
}
