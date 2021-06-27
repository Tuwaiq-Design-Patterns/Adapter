using System;

namespace Adapter_Design_Pattern
{


    //The Pillow python library that allow us to add text on an image but does not support arabic language
    class Pillow
    {
        public string AddTextOnImage()
        {
            return " :( ﻊﺋﺍﺭ ﻦﻣ ﺮﺜﻛﻻﺍ ءاﺩﻻﺍ ﻰﻠﻋ هﺭﻮﻧﻭ هﺭﺎﺳ اﺮﻜﺷ ";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    class Adapter 
    {
        private readonly Pillow _adaptee;

        public Adapter(Pillow adaptee)
        {
            this._adaptee = adaptee;
        }

        public string AddTextOnImageThatSupportArabic()
        {
            char[] charArray = this._adaptee.AddTextOnImage().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pillow adaptee = new Pillow();

            Console.WriteLine("Before using Adapter:");

            Console.WriteLine(adaptee.AddTextOnImage()) ;

            Console.WriteLine("After using Adapter:");

            Adapter arabic_language_support = new Adapter(adaptee);

         
            Console.WriteLine(arabic_language_support.AddTextOnImageThatSupportArabic());
        }
    }
}
