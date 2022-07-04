using Microsoft.EntityFrameworkCore;
using WeatherApp.Business.Data;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Models;

namespace WeatherApp.Business.Services
{
    public class HumidityService : IHumidityService
    {
        private readonly DataContext _context;

        public HumidityService(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Get all humidity records by date  
        /// </summary>  
        /// <param name="date">date</param>  
        /// <returns>ServiceResponse of humidity</returns>  
        public async Task<ServiceResponse<List<Humidity>>> GetDataByDate(DateTime date)
        {
            return new ServiceResponse<List<Humidity>>
            {
                Data = await _context.Humidity
                    .Where(h => h.TimeStamp.Date.Equals(date.Date))
                    .OrderBy(h => h.TimeStamp)
                    .Select(t => new Humidity
                    {
                        TimeStamp = t.TimeStamp,
                        Measure = float.Parse(t.Measure.Replace(',', '.')).ToString().Replace('.', ',')
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
