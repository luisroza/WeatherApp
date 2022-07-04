using WeatherApp.Business.Models;

namespace WeatherApp.Business.Interfaces
{
    public interface IWeatherService
    {
        Task<ServiceResponse<List<Weather>>> GetDataByDate(DateTime date);
    }
}
