using System;

namespace AdapterPractice
{
    class Program
    {



        public interface IAdapter
        {
            public void getAudio(string file_name); 
        }


        public class Adapter : IAdapter
        {
            private readonly MediaPlayer _adaptee;

            public Adapter(MediaPlayer adaptee)
            {
                this._adaptee = adaptee;
            }


            public void getAudio(string file_name)
            {
                Console.WriteLine("Playing: \t"+ file_name + this._adaptee.getFileAudio());
            }
        }

        public class MediaPlayer
        {
            public string getFileAudio()
            {
                //adapting the file so the clinet can accept audio file.
                return ".mp3"; 
            }

            //unused, just another example of a service.
            public string getFilePicture() 
            {
                return ".png"; //*screenshots*
            }
        }

        static void Main(string[] args)
        {
            MediaPlayer adaptee = new MediaPlayer();
            IAdapter file = new Adapter(adaptee);

            file.getAudio("Podcast");
        }
    }
}
