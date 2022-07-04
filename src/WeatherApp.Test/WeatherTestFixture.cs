using Bogus;
using WeatherApp.Business.Models;

namespace WeatherApp.Test
{
    public class WeatherTestFixture
    {
        public List<Weather> GenerateWeatherList(int quantity, DateTime startDate, DateTime endDate)
        {
            var weatherList = new Faker<Weather>()
                .CustomInstantiator(f => new Weather
                {
                    TimeStamp = RandomDate(startDate, endDate),
                    Temperature = RandomFloat(-100, 100).ToString(),
                    Humidity = RandomFloat(0, 100).ToString(),
                    Rainfall = RandomFloat(0, 100).ToString()
                });

            return weatherList.Generate(quantity);
        }

        public List<Temperature> GenerateTemperaturesList(int quantity, DateTime startDate, DateTime endDate)
        {
            var temperatures = new Faker<Temperature>()
                .CustomInstantiator(f => new Temperature
                {
                    TimeStamp = RandomDate(startDate, endDate),
                    Measure = RandomFloat(-100, 100).ToString()
                });

            return temperatures.Generate(quantity);
        }

        public List<Humidity> GenerateHumidityList(int quantity, DateTime startDate, DateTime endDate)
        {
            var humidity = new Faker<Humidity>()
                .CustomInstantiator(f => new Humidity()
                {
                    TimeStamp = RandomDate(startDate, endDate),
                    Measure = RandomFloat(0, 100).ToString()
                });

            return humidity.Generate(quantity);
        }

        public List<Rainfall> GenerateRainfallList(int quantity, DateTime startDate, DateTime endDate)
        {
            var rainfall = new Faker<Rainfall>()
                .CustomInstantiator(f => new Rainfall()
                {
                    TimeStamp = RandomDate(startDate, endDate),
                    Measure = RandomFloat(0, 100).ToString()
                });

            return rainfall.Generate(quantity);
        }

        private DateTime RandomDate(DateTime startDate, DateTime endDate)
        {
            var timeSpan = endDate - startDate;
            var newSpan = new TimeSpan(0, new Random().Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + newSpan;
        }

        private float RandomFloat(float min, float max)
        {
            return (new Random().NextSingle() * (max - min) + min);
        }
    }
}
