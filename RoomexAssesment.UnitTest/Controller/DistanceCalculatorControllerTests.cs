using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RoomexAssesment.API.Controllers;
using RoomexAssesment.API.Model;
using RoomexAssesment.Services;
using RoomexAssesment.Services.DTO;

namespace RoomexAssesment.UnitTest.Controller
{
    public class DistanceCalculatorServiceTests
    {
        private readonly Mock<IDistanceCalculatorService> _mockDistanceCalculatorService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DistanceCalculatorController _controller;
        public DistanceCalculatorServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockDistanceCalculatorService = new Mock<IDistanceCalculatorService>();
            _controller = new DistanceCalculatorController(_mockDistanceCalculatorService.Object, _mockMapper.Object);
        }
        [Fact]
        public void When_CoordinatesAreSame_Should_Return_Zero()
        {
            var coordinate = new CoordinateModel { FirstCityLatitude = 1, FirstCityLongitude = 1, SecondCityLatitude = 1, SecondCityLongitude = 1 };
            var result = _controller.Get(coordinate);
            var distance = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(0, distance.Value);
        }

        [Fact]
        public void When_CoordinatesAreSame_Should_Not_CalculateDistance()
        {
            var coordinate = new CoordinateModel { FirstCityLatitude = 1, FirstCityLongitude = 1, SecondCityLatitude = 1, SecondCityLongitude = 1 };
            var result = _controller.Get(coordinate);
            _mockDistanceCalculatorService.Verify(r => r.Calculate(It.IsAny<CoordinateDTO>()), Times.Never);
        }

        [Fact]
        public void When_CoordinatesAreNotSame_Should_CalculateDistance()
        {
            var coordinate = new CoordinateModel { FirstCityLatitude = 1, FirstCityLongitude = 2, SecondCityLatitude = 1, SecondCityLongitude = 1 };
            var result = _controller.Get(coordinate);
            _mockDistanceCalculatorService.Verify(r => r.Calculate(It.IsAny<CoordinateDTO>()), Times.Once);
        }
    }
}