using System;
using System.Collections.Generic;

namespace DP__Adapter
{
   public interface ITarget
    {
        List<string> GetProducts();
    }

    public class VendorAdaptee
    {
        public List<string> GetListOfProducts()
        {
            List<string> products = new List<string>();
            products.Add("Computer");
            products.Add("Television");
            products.Add("Printer");
       
            return products;
        }
    }



    class VendorAdapter : ITarget
    {
        public List<string> GetProducts()
        {
            VendorAdaptee adaptee = new VendorAdaptee();
            return adaptee.GetListOfProducts();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ITarget adapter = new VendorAdapter();
            Console.WriteLine("VendorAdaptee interface is incompatible with the client, But with VendorAdapter > client can call it's method.");

            foreach (string product in adapter.GetProducts())
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
        }
    }
}








