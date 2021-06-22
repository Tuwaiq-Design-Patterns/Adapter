using static System.Console;
namespace adapter_dp
{
    public class IAdapter
    {
        public float Boiling { get; set; }
        public float Melting { get; set; }
        public double Weight { get; set; }
        public string Formula { get; set; }
        public virtual void Print()
        {
            WriteLine("\nCompound: Unknown ------ ");
        }
    }
}