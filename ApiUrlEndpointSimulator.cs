using System;

namespace Adapter
{
    class ApiUrlEndpointSimulator
    {
        public void MakeCall(string input)
        {
            Console.WriteLine($"An API call was made to {input}");
        }
    }
}