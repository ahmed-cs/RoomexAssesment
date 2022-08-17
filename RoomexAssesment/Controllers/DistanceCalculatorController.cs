using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomexAssesment.Services;
using RoomexAssesment.API.Model;
using AutoMapper;
using RoomexAssesment.Services.DTO;

namespace RoomexAssesment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceCalculatorController : ControllerBase
    {
        private readonly IDistanceCalculatorService _distanceCalculatorService;
        private readonly IMapper _mapper;
        public DistanceCalculatorController(IDistanceCalculatorService distanceCalculatorService, IMapper mapper)
        {
            _distanceCalculatorService = distanceCalculatorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]CoordinateModel coordinates)
        {

            if (coordinates.FirstCityLatitude == coordinates.SecondCityLatitude &&
                coordinates.FirstCityLongitude == coordinates.SecondCityLongitude)
                return Ok(0);

            var coordinateDTO = _mapper.Map<CoordinateDTO>(coordinates);

            return Ok(_distanceCalculatorService.Calculate(coordinateDTO));
        }
        
    }

}