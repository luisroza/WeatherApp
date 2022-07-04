namespace WeatherApp.Business.Models
{
    public class Weather
    {
        public DateTime TimeStamp { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Rainfall { get; set; }
    }
}
