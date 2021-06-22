using System;

namespace Adopter
{
    class Program
    {
        static void Main(string[] args)
        {
            audioPlayermp3 mp3 = new audioPlayermp3();
            mp3.play("song.mp3");
           // mp3.play("song.mp4");
           // mp3.play("song.vlc");
        }
    }

    public interface advanceMediaPlayer
    {
        void MP4();
        void VLC();
    }

    class mp4Player : advanceMediaPlayer
    {
        public void MP4()
        {
         
            Console.WriteLine("run mp4 file");
        }

        public void VLC()
        {
            throw new NotImplementedException();
        }
    }

    class vlcPlayer : advanceMediaPlayer
    {
        public void MP4()
        {
      
            throw new NotImplementedException();
        }

        public void VLC()
        {
          
            Console.WriteLine("run vlc file");
        }
    }

    public interface audioPlayer
    {
        void play(string file);
    }


    class audioPlayermp3 : audioPlayer
    {

        adapter Myadapter;

        public void play(string file)
        {
            if (file.EndsWith("mp3"))
            {
                Console.WriteLine("run mp3 file");
            }
            else
            {
                Myadapter = new adapter(file);
                Myadapter.play(file);
            }
           // throw new NotImplementedException();
        }

        public void VLC()
        {

            Console.WriteLine("run vlc file");
        }
    }
    class adapter : audioPlayer
    {

        advanceMediaPlayer adv;
        public adapter(string file)
        {
            if (file.EndsWith("mp4"))
            {
                adv = new mp4Player();
            }
            else
            {
                adv = new vlcPlayer();
            }

        }
        public void play(string file)
        {
            if (file.EndsWith("mp4"))
            {
                adv.MP4();
            }
            else
            {
                adv.VLC();
            }
          
        }
    }
}
