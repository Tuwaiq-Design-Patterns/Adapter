using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IJsonToObject jsonToXml = new JsonToObject();

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.cheapshark.com/api/1.0/deals?storeID=1&upperPrice=15");
                jsonToXml.ConvertToObject(result);
            }
        }
        //     static void SerializeToXml(Type type, object o, string path)
    //     {
    //         if (File.Exists(path)) File.Delete(path);
    //
    //         XmlSerializer xmlSerializer = new XmlSerializer(type);
    //         TextWriter writer = new StreamWriter(path);
    //         xmlSerializer.Serialize(writer, o);
    //         writer.Close();
    //     }
    //     static object DeserializeFromXml(Type type, string path)
    //     {
    //         object o = null;
    //
    //         if (File.Exists(path))
    //         {
    //             XmlSerializer xmlSerializer = new XmlSerializer(type);
    //             TextReader reader = new StreamReader(path);
    //             o = xmlSerializer.Deserialize(reader);
    //             reader.Close();
    //         }
    //         
    //         return o;
    //     }
    
    }
    
    public class Games
    {
        public string internalName { get; set; }
        public string title { get; set; }
        public string metacriticLink { get; set; }
        public string dealID { get; set; }
        public string storeID { get; set; }
        public string gameID { get; set; }
        public string salePrice { get; set; }
        public string normalPrice { get; set; }
        public string isOnSale { get; set; }
        public string savings { get; set; }
        public string metacriticScore { get; set; }
        public string steamRatingText { get; set; }
        public string steamRatingPercent { get; set; }
        public string steamRatingCount { get; set; }
        public string steamAppID { get; set; }
        public int releaseDate { get; set; }
        public int lastChange { get; set; }
        public string dealRating { get; set; }
        public string thumb { get; set; }
    }
    public class GamesDto
    {
        public string title { get; set; }
        public string gameID { get; set; }
        public string salePrice { get; set; }
        public string normalPrice { get; set; } 
        public string steamRatingText { get; set; }
        public string dealRating { get; set; }
    }

    public interface IJsonToObject
    {
        public void ConvertToObject(string json);
    }

    public class JsonToObject : IJsonToObject
    {
        private XmlWrite adaptee;

        public JsonToObject()
        {
            this.adaptee = new XmlWrite();
        }
        public void ConvertToObject(string json)
        {
            var mappedData = JsonSerializer.Deserialize<List<Games>>(json);
            var games = new List<GamesDto>();
                
            foreach (var game in mappedData)
            {
                games.Add(new GamesDto()
                {
                    title = game.title,
                    gameID = game.gameID,
                    salePrice = game.salePrice,
                    normalPrice = game.normalPrice,
                    steamRatingText = game.steamRatingText,
                    dealRating = game.dealRating
                });
            }

            if (games != null)
            {
                foreach (var game in games)
                {
                    Console.WriteLine(game.title);
                }
                
                this.adaptee.WriteToXml(typeof(List<GamesDto>), games);
            }
        }
    }

    public class XmlWrite
    {
        private string path = @"C:\Users\sulta\Desktop\games.save";
        
        public void WriteToXml(Type type, object o)
        {
            if (File.Exists(this.path)) File.Delete(this.path);

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            TextWriter writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, o);
            writer.Close();
        }
    }
}