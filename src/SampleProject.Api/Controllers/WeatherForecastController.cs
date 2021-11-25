using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleProject.Core.Dto.WeatherForecast;
using SampleProject.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _pipeline;
        public WeatherForecastController(IWeatherForecastService pipeline)
        {
            _pipeline = pipeline;
        }
        [HttpGet]
        [Route("")]
        public async Task<ListWheatherForecastResponseDto> Get()
        {
            return await _pipeline.Obter(new ListWheatherForecastRequestDto());
        }
        [HttpGet]
        [Route("/com-error")]
        public async Task<ListWheatherForecastResponseDto> GetComError()
        {
            return await _pipeline.ObterComError(new ListWheatherForecastRequestDto());
        }
        [HttpGet]
        [Route("/com-error-tratado")]
        public async Task<ListWheatherForecastResponseDto> GetComErrorTratado()
        {
            return await _pipeline.ObterComErrorTratado(new ListWheatherForecastRequestDto());
        }
    }
}
