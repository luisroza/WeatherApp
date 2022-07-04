using WeatherApp.Business.Models;

namespace WeatherApp.Business.Interfaces
{
    public interface IHumidityService
    {
        Task<ServiceResponse<List<Humidity>>> GetDataByDate(DateTime date);
    }
}
