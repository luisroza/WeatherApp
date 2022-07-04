using Moq;
using Xunit;
using Moq.AutoMock;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Services;

namespace WeatherApp.Test
{
    public class WeatherTests
    {
        private readonly WeatherTestFixture _weatherTestFixture;

        private readonly DateTime _date = new (2019, 1, 10);
        private readonly DateTime _startDate = new (2019, 1, 8);
        private readonly DateTime _endDate = new (2019, 1, 12);
        private const int DataCount = 1000;

        public WeatherTests(WeatherTestFixture weatherTestFixture)
        {
            _weatherTestFixture = weatherTestFixture;
        }

        [Fact(DisplayName = "Get All Weather data by Date")]
        public void WeatherService_GetWeatherDataByDate()
        {
            // Arrange
            var mocker = new AutoMocker();
            var weatherService = mocker.CreateInstance<WeatherService>();
            var weatherListMock = _weatherTestFixture.GenerateWeatherList(DataCount, _startDate, _endDate);

            mocker.GetMock<IWeatherService>().Setup(c => c.GetDataByDate(_date).Result.Data)
                .Returns(weatherListMock);

            // Act
            var weatherList = weatherService.GetDataByDate(_date).Result.Data;

            // Assert
            var count = weatherListMock.Count(m => m.TimeStamp.Date.Equals(_date.Date));
            mocker.GetMock<IWeatherService>().Verify(r => r.GetDataByDate(_date), Times.Once);
            Assert.True(weatherList != null && weatherList.Count() == count);
            Assert.False(weatherList != null && weatherList.Count() != count);
        }

        [Fact(DisplayName = "Get Temperatures by Date")]
        public void TemperatureService_GetTemperatureByDate()
        {
            // Arrange
            var mocker = new AutoMocker();
            var temperatureService = mocker.CreateInstance<TemperatureService>();
            var temperatureMockList = _weatherTestFixture.GenerateTemperaturesList(DataCount, _startDate, _endDate);

            mocker.GetMock<ITemperatureService>().Setup(c => c.GetDataByDate(_date).Result.Data)
                .Returns(_weatherTestFixture.GenerateTemperaturesList(DataCount, _startDate, _endDate));

            // Act
            var temperatureList = temperatureService.GetDataByDate(_date).Result.Data;

            // Assert 
            var count = temperatureMockList.Count(m => m.TimeStamp.Date.Equals(_date.Date));
            mocker.GetMock<ITemperatureService>().Verify(r => r.GetDataByDate(_date), Times.Once);
            Assert.True(temperatureList != null && temperatureList.Count() == count);
            Assert.False(temperatureList != null && temperatureList.Count() != count);
        }

        [Fact(DisplayName = "Get Humidity percentage by Date")]
        public void HumidityService_GetHumidityPercentageByDate()
        {
            // Arrange
            var mocker = new AutoMocker();
            var humidityService = mocker.CreateInstance<HumidityService>();
            var humidityMockList = _weatherTestFixture.GenerateHumidityList(DataCount, _startDate, _endDate);

            mocker.GetMock<IHumidityService>().Setup(c => c.GetDataByDate(_date).Result.Data)
                .Returns(_weatherTestFixture.GenerateHumidityList(DataCount, _startDate, _endDate));

            // Act
            var humidityList = humidityService.GetDataByDate(_date).Result.Data;

            // Assert
            var count = humidityMockList.Count(m => m.TimeStamp.Date.Equals(_date.Date));
            mocker.GetMock<IHumidityService>().Verify(r => r.GetDataByDate(_date), Times.Once);
            Assert.True(humidityList != null && humidityList.Count() == count);
            Assert.False(humidityList != null && humidityList.Count() != count);
        }

        [Fact(DisplayName = "Get Rainfall percentage by Date")]
        public void RainfallService_GetRainfallPercentageByDate()
        {
            // Arrange
            var mocker = new AutoMocker();
            var rainfallService = mocker.CreateInstance<RainfallService>();
            var rainfallMockList = _weatherTestFixture.GenerateRainfallList(DataCount, _startDate, _endDate);

            mocker.GetMock<IRainfallService>().Setup(c => c.GetDataByDate(_date).Result.Data)
                .Returns(_weatherTestFixture.GenerateRainfallList(DataCount, _startDate, _endDate));

            // Act
            var rainfallList = rainfallService.GetDataByDate(_date).Result.Data;

            // Assert
            var count = rainfallMockList.Count(m => m.TimeStamp.Date.Equals(_date.Date));
            mocker.GetMock<IRainfallService>().Verify(r => r.GetDataByDate(_date), Times.Once);
            Assert.True(rainfallList != null && rainfallList.Count() == count);
            Assert.False(rainfallList != null && rainfallList.Count() != count);
        }
    }
}