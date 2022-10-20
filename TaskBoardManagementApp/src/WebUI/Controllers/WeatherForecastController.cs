using Microsoft.AspNetCore.Mvc;
using TaskBoardManagementApp.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace TaskBoardManagementApp.WebUI.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
