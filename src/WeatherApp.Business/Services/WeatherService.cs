using Microsoft.EntityFrameworkCore;
using WeatherApp.Business.Data;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Models;

namespace WeatherApp.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly DataContext _context;

        public WeatherService(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Get all weather records (temperature, humidity and rainfall) by date  
        /// </summary>  
        /// <param name="date">date</param>  
        /// <returns>ServiceResponse of weather</returns>  
        public async Task<ServiceResponse<List<Weather>>> GetDataByDate(DateTime date)
        {
            return new ServiceResponse<List<Weather>>
            {
                Data = await _context.Weather
                    .Where(h => h.TimeStamp.Date.Equals(date.Date))
                    .OrderBy(h => h.TimeStamp)
                    .Select(t => new Weather
                    {
                        TimeStamp = t.TimeStamp,
                        Temperature = float.Parse(t.Temperature.Replace(',', '.')).ToString().Replace('.', ','),
                        Rainfall = float.Parse(t.Rainfall.Replace(',', '.')).ToString().Replace('.', ','),
                        Humidity = float.Parse(t.Humidity.Replace(',', '.')).ToString().Replace('.', ',')
                    })
                    .ToListAsync()
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}