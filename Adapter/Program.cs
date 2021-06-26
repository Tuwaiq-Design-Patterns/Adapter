using System;

namespace Adapter
{
    public interface IWeatherApi
    {
        double GetTemperature(string cityName);
    }

    class WeatherApi : IWeatherApi
    {
        public double GetTemperature(string cityName) 
        { 
            if (cityName == "Jeddah") 
            { 
                return 34.2;
            }
            
            if (cityName == "Riyadh")
            { 
                return 43.8; 
            }
            
            return 0; 
        }
    }
    
    class WeatherAdapter : IWeatherApi
    {
        private WeatherApi _weatherApi;
        public WeatherAdapter(WeatherApi weatherApi)
        {
            _weatherApi = weatherApi;
        }
        public double GetTemperature(string zipcode) 
        {
            // get the city name from zipcode
            string cityName = GetCityName(zipcode);

            // invoke the weather api with the city name
            return _weatherApi.GetTemperature(cityName);
        }

        private string GetCityName(string zipCode)
        {
            if (zipCode == "22237")
            {
                return "Jeddah";
            }

            if (zipCode == "12232")
            {
                return "Riyadh";
            }

            return "";
        }
    }

    
    
    class Program
    {
        static void Main(string[] args)
        {
            var weather = new WeatherApi();
            var apiAdapter = new WeatherAdapter(weather);
            Console.WriteLine("Get weather by city name: ");
            Console.WriteLine($"Jeddah: {weather.GetTemperature("Jeddah")}");
            Console.WriteLine($"Riyadh: {weather.GetTemperature("Riyadh")}");
            
            Console.WriteLine("Get weather by zipcode: ");
            Console.WriteLine($"Jeddah: {apiAdapter.GetTemperature("22237")}");
            Console.WriteLine($"Riyadh: {apiAdapter.GetTemperature("12232")}");
            
        }
    }
}