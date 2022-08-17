using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RoomexAssesment.API.Controllers;
using RoomexAssesment.API.Model;
using RoomexAssesment.Services;
using RoomexAssesment.Services.DTO;
using System.Collections;

namespace RoomexAssesment.UnitTest.Services
{
    public class DistanceCalculatorServiceTests
    {
        private readonly DistanceCalculatorService _distanceCalculatorService;
        public DistanceCalculatorServiceTests()
        {
            _distanceCalculatorService = new DistanceCalculatorService();
        }

        public static IEnumerable<object[]> Coordinates =>
        new List<object[]>
        {
            new object[] { new CoordinateDTO { FirstCityLatitude=53.297975,FirstCityLongitude=-6.372663,SecondCityLatitude=41.385101,SecondCityLongitude=-81.440440},5536.34 },
            new object[] { new CoordinateDTO { FirstCityLatitude = 1, FirstCityLongitude = 1, SecondCityLatitude = 1, SecondCityLongitude = 1},0 },
            new object[] { new CoordinateDTO { FirstCityLatitude = 73.297975, FirstCityLongitude = 26.372663, SecondCityLatitude = 62.385101, SecondCityLongitude = 41.440440 },1358.98 },
            new object[] { new CoordinateDTO { FirstCityLatitude = 83.297975, FirstCityLongitude = 100.372663, SecondCityLatitude = 82.385101, SecondCityLongitude = 61.440440 }, 537.89 }
        };

        [Theory]
        [MemberData(nameof(Coordinates))]
        public void When_CalculateDistance_Should_Return_Distance(CoordinateDTO coordinate,double expected)
        {
            var result = _distanceCalculatorService.Calculate(coordinate);
            Assert.Equal(expected, result);
        }


    }

}