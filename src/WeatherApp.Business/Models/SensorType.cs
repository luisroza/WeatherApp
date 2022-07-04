namespace WeatherApp.Business.Models
{
    public abstract class SensorType
    {
        public DateTime TimeStamp { get; set; }

        public string Measure { get; set; }
    }
}
