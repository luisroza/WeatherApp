using Microsoft.EntityFrameworkCore;
using WeatherApp.Business.Data;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Models;

namespace WeatherApp.Business.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly DataContext _context;

        public TemperatureService(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Get all temperature records by date  
        /// </summary>  
        /// <param name="date">date</param>  
        /// <returns>ServiceResponse of temperature</returns>  
        public async Task<ServiceResponse<List<Temperature>>> GetDataByDate(DateTime date)
        {
            var result = await _context.Temperatures
                .Where(h => h.TimeStamp.Date.Equals(date.Date))
                .OrderBy(h => h.TimeStamp)
                .Select(t => new Temperature
                {
                    TimeStamp = t.TimeStamp,
                    Measure = float.Parse(t.Measure.Replace(',', '.')).ToString().Replace('.', ',')
                })
                .ToListAsync();

            return new ServiceResponse<List<Temperature>>
            {
                Data = result
            };
        }
    }
}
