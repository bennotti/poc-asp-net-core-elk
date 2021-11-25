using SampleProject.Core.Dto.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<ListWheatherForecastResponseDto> Obter(ListWheatherForecastRequestDto request);
        Task<ListWheatherForecastResponseDto> ObterComError(ListWheatherForecastRequestDto request);
        Task<ListWheatherForecastResponseDto> ObterComErrorTratado(ListWheatherForecastRequestDto request);
    }
}
