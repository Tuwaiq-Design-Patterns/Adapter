using System;

namespace AdapterDrill
{
    class Program
    {

        static void Main(string[] args)
        {
            USB USB = new USB();
            Ethernet ethernet = new Ethernet();
            IUSB ethernetAdapter = new EthernetAdapter(ethernet);
            USB.TransferData("Mansour");
            ethernet.TransferData("Mansour");
            Console.WriteLine("Now using Ethernet Adapter");
            ethernetAdapter.TransferData("Mansour");
        }
    }
    
        public interface IEthernet
        {
            void TransferData(string data);
        }
    
        public interface IUSB
        {
            void TransferData(string data);
        }
        
        public class Ethernet : IEthernet
        {
            public void TransferData(string data)
            {
                Console.WriteLine($"Transfering '{data}' through Ethernet...");
            }
        }
        
        public class EthernetAdapter : IUSB
        {
            private readonly IEthernet ethernet;

            public EthernetAdapter(IEthernet ethernet)
            {
                this.ethernet = ethernet;
            }

            public void TransferData(string data)
            {
                this.ethernet.TransferData(data);
            }
        }
        
        public class USB : IUSB
        {
            public void TransferData(string data)
            {
                Console.WriteLine($"Transfering '{data}' through USB...");
            }
        }
}