using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Business.Data;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Models;

namespace WeatherApp.Business.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly DataContext _context;

        public RainfallService(DataContext context)
        {
            _context = context;
        }

        /// <summary>  
        /// Get all rainfall records by date  
        /// </summary>  
        /// <param name="date">date</param>  
        /// <returns>ServiceResponse of rainfall</returns>  
        public async Task<ServiceResponse<List<Rainfall>>> GetDataByDate(DateTime date)
        {
            return new ServiceResponse<List<Rainfall>>
            {
                Data = await _context.Rainfall!
                    .Where(h => h.TimeStamp.Date.Equals(date.Date))
                    .OrderBy(h => h.TimeStamp)
                    .Select(t => new Rainfall()
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
