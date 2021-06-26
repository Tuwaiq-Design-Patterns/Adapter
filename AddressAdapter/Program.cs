using System;

namespace AddressAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressProvider addressProvider = new AddressProvider("StreetName", "Neighborhood", "City", 1234, 5678);

            IStringAddress address = new AddressAdapter(addressProvider);

            Console.WriteLine(address.GetAddress());
        }
    }
}