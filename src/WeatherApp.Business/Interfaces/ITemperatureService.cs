using WeatherApp.Business.Models;

namespace WeatherApp.Business.Interfaces
{
    public interface ITemperatureService
    {
        Task<ServiceResponse<List<Temperature>>> GetDataByDate(DateTime date);
    }
}
