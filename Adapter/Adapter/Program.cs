using System;

namespace Adapter
{
    class vid
    {
        public string str;
        public void MP4(string mp)
        {
            this.str = mp;
        }
    }

    public interface IMP4ToMP3
    {
        void ToMP3();
    }
    class Adapter : IMP4ToMP3
    {
        private readonly vid _adaptee;
        public void ToMP3()
        {

            string msg = _adaptee.str;
            if(_adaptee.str.Substring(_adaptee.str.Length-1) == "4")
                Console.WriteLine(msg.Replace("4","3"));
            else
                Console.WriteLine("Not mp4 (ಥ _ ಥ)");

        }
        public Adapter(vid adaptee)
        {
            this._adaptee = adaptee;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            vid mp = new vid();
            mp.MP4("Zelda.mp4");
            IMP4ToMP3 converter = new Adapter(mp);
            converter.ToMP3();
        }
    }
}
