using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play("mp3", "LoveStory.mp3");
            audioPlayer.Play("mp4", "Bing Bang.mp4");
            audioPlayer.Play("avi", "Hall of fame.avi");
            audioPlayer.Play("vlc", "Not to be okay.vlc");
        }
    }
    public interface IMediaPlayer
    {
        public void Play(string audioType, string fileName);
    }

    public interface IAdvancedMediaPlayer
    {
        public void PlayVLC(string fileName);
        public void PlayMP4(string fileName);
    }

    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void PlayVLC(string fileName)
        {
            Console.WriteLine("Playing VLC file. Name: " + fileName);
        }

        public void PlayMP4(string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void PlayMP4(string fileName)
        {
            Console.WriteLine("Playing MP4 file. Name: " + fileName);
        }

        public void PlayVLC(string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public class MediaAdapter : IMediaPlayer
    {

        IAdvancedMediaPlayer advancedMusicPlayer;

        public MediaAdapter(string audioType)
        {

            if (audioType.Equals("vlc"))
            {
                advancedMusicPlayer = new VlcPlayer();

            }
            else if (audioType.Equals("mp4"))
            {
                advancedMusicPlayer = new Mp4Player();
            }
        }

        public void Play(string audioType, string fileName)
        {

            if (audioType.Equals("vlc"))
            {
                advancedMusicPlayer.PlayVLC(fileName);
            }
            else if (audioType.Equals("mp4"))
            {
                advancedMusicPlayer.PlayMP4(fileName);
            }
        }

    }

    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void Play(string audioType, string fileName)
        {

            if (audioType.Equals("mp3"))
            {
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            }

            else if (audioType.Equals("vlc") || audioType.Equals("mp4"))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.Play(audioType, fileName);
            }

            else
            {
                Console.WriteLine("Invalid media. " + audioType + " format not supported");
            }
        }
    }
}
