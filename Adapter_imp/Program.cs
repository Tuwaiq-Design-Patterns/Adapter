using System;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using System.Text.Json;
namespace Adapter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IFeedAdapter feed = new JsonAdapter();
            var json = await feed.getFeedAsync("https://feeds.megaphone.fm/ADL9840290619");
            System.Console.WriteLine(json);
        }
    }

    class JsonAdapter : IFeedAdapter
    {
        private Feed feed; // wrap the serviec object 
        public async Task<string> getFeedAsync( string url )
        {
            feed = await FeedReader.ReadAsync(url);
             RssChannel rc = new RssChannel
             {
                 Url = url,
                 Title = feed.Title,
                 Description  = feed.Description,
                 Link = feed.Link
             };
            
            return JsonSerializer.Serialize(rc, new JsonSerializerOptions 
            {
                WriteIndented = true    
            });
        }

    }

    interface IFeedAdapter
    {
        Task<string> getFeedAsync( string url );
    }

    class RssChannel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

    }
}
