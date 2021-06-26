using System;
namespace Adapter
{
    public interface IFormat
    {
        public void Format(string fileName, string formatType);
    }

    public class Mp3 : IFormat
    {
        public void Format(string fileName, string formatType)
        {
            Console.WriteLine("{0} Convert to MP3 ", fileName);
        }
    }
    public class AAC: IFormat
    {
        public void Format(string fileName, string formatType)
        {
            Console.WriteLine("{0} Convert to AAC ", fileName);
        }
    }
    public class FormatManager
    {
        private readonly IFormat convertService;
        public FormatManager(IFormat convertService)
        {
            this.convertService = convertService;
        }
        public void Format(string fileName, string formatType)
        {
            this.convertService.Format(fileName, formatType);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Mp3 mp3 = new Mp3();
            AAC aac = new AAC();
            var Mp3FormatManager = new FormatManager(mp3);
            var AccFormatManager = new FormatManager(aac);
            Console.WriteLine("Choose Audio Format You Want to Convert To ?\n 1-MP3 \n 2-ACC ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Mp3FormatManager.Format("song1", "Mp3");
                    break;
                case 2:
                    AccFormatManager.Format("song2", "Acc");
                    break;
                default:
                    Console.WriteLine("Invalid choice..");
                    break;
            }
        }
    }
}