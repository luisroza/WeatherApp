using WeatherApp.Business.Models;

namespace WeatherApp.Business.Interfaces
{
    public interface IRainfallService
    {
        Task<ServiceResponse<List<Rainfall>>> GetDataByDate(DateTime date);
    }
}
