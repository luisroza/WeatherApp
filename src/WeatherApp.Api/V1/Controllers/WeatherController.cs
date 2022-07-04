using Microsoft.AspNetCore.Mvc;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Models;

namespace WeatherApp.Api.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly ITemperatureService _temperatureService;
        private readonly IRainfallService _rainfallService;
        private readonly IHumidityService _humidityService;
        private readonly IWeatherService _weatherService;

        public WeatherController(ITemperatureService temperatureService, IRainfallService rainfallService, IHumidityService humidityService, IWeatherService weatherService)
        {
            _humidityService = humidityService;
            _rainfallService = rainfallService;
            _temperatureService = temperatureService;
            _weatherService = weatherService;
        }

        /// <summary>  
        /// Returns weather records (temperature, humidity and rainfall) by date, sensorType parameter determines the object type returned.
        /// Returns a list of weather records if sensorType is empty. 
        /// </summary>  
        /// <param name="date">date</param>
        /// <param name="sensorType"></param>  
        /// <returns>ServiceResponse of weather records</returns>  
        [HttpGet("/{date:datetime}/{sensorType?}")]
        public async Task<ActionResult<ServiceResponse<List<SensorType>>>> GetDataByDate(DateTime date,
            string? sensorType)
        {
            if (string.IsNullOrEmpty(sensorType))
            {
                var result = await _weatherService.GetDataByDate(date);
                return Ok(result);
            }

            switch (sensorType.ToLower())
            {
                case "temperature":
                    var tempResult = await _temperatureService.GetDataByDate(date);
                    return Ok(tempResult);
                case "humidity":
                    var humResult = await _humidityService.GetDataByDate(date);
                    return Ok(humResult);
                case "rainfall":
                    var rainResult = await _rainfallService.GetDataByDate(date);
                    return Ok(rainResult);
            }

            return BadRequest(sensorType);
        }
    }
}
