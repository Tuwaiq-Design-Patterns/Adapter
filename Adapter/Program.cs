using System;

namespace Adapter
{
    public interface UsbCharger
    {
        string ChargePhone();
    }
    class IPhone
    {
        public string LightningPort()
        {
            return "Charging IPhone with the Lightning port";
        }
    }
    class UsbToLighning : UsbCharger
    {
        private readonly IPhone _IPhone;

        public UsbToLighning(IPhone iphone)
        {
            this._IPhone = iphone;
        }
        public string ChargePhone()
        {
            return "The USB to Lighning adapter is: " + this._IPhone.LightningPort();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IPhone iphone = new IPhone();

            UsbCharger usbCable = new UsbToLighning(iphone);

            Console.WriteLine("The IPhone Lighning port is incompatible with the Usb charger. " +
                "\n" +
                "We need to use an adapter for our USB charger.");
            Console.WriteLine(usbCable.ChargePhone());
        }
    }
}
