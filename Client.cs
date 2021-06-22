using static System.Console;

namespace adapter_dp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new IAdapter().Print();
            new Adapter("Water").Print();
            new Adapter("Benzene").Print();
            new Adapter("Ethanol").Print();
        }
    }
}