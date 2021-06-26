using System;

namespace AdapterProject
{//Adapter pattern
	class Program
    {
		public interface MediaPlayer
		{
			public void Play(string audioType, string fileName);
		}
		public interface AdvancedMediaPlayer
		{
			public void playMov(string fileName);
			public void playMp4(string fileName);
		}


		public class MovPlayer : AdvancedMediaPlayer
		{
         public void playMov(string fileName)
		{
			Console.WriteLine("Playing vlc file. Name: " + fileName);
		}

            public void playMp4(string fileName)
            {
                throw new NotImplementedException();
            }
        }
    
         public class Mp4Player : AdvancedMediaPlayer
		{


       

            public void playMov(string fileName)
            {
            }

            public void PlayMp4(string fileName)
		{
				Console.WriteLine("Playing mp4 file. Name: " + fileName);
		}

            public void playMp4(string fileName)
            {
            }
        }


public class MediaAdapter : MediaPlayer
		{

			AdvancedMediaPlayer advancedMusicPlayer;


   public MediaAdapter(string audioType)
		{

			if (audioType.Equals("Mov"))
			{
				advancedMusicPlayer = new MovPlayer();

			}
			else if (audioType.Equals("mp4"))
			{
				advancedMusicPlayer = new Mp4Player();
			}
		}

		
   public void Play(string audioType, string fileName)
		{

			if (audioType.Equals("Mov"))
			{
				advancedMusicPlayer.playMov(fileName);
			}
			else if (audioType.Equals("mp4"))
			{
				advancedMusicPlayer.playMp4(fileName);
			}
		}
	}

		public class AudioPlayer : MediaPlayer
		{
			MediaAdapter mediaAdapter;

			
   public void Play(string audioType, string fileName)
		{

			if (audioType.Equals("mp3"))
			{
				Console.WriteLine("Playing mp3 file. Name: " + fileName);
			}

			else if (audioType.Equals("Mov") || audioType.Equals("mp4"))
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


	static void Main(string[] args)
        {
			AudioPlayer Player = new AudioPlayer();

			Player.Play("mp3", "Quran.mp3");
			Player.Play("mp4", "azkar.mp4");
			Player.Play("Mov", "Demo.Mov");
			Player.Play("vlc", "Sky.vlc");
		}
    }
}
