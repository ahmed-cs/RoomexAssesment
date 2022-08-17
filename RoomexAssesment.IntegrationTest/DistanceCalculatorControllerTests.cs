using Microsoft.AspNetCore.Mvc.Testing;
using RoomexAssesment.API.Model;

namespace RoomexAssesment.IntegrationTest
{
    public class DistanceCalculatorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public DistanceCalculatorControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        public static IEnumerable<object[]> Coordinates =>
        new List<object[]>
        {
            new object[] { new CoordinateModel { FirstCityLatitude=53.297975,FirstCityLongitude=-6.372663,SecondCityLatitude=41.385101,SecondCityLongitude=-81.440440},5536.34 },
            new object[] { new CoordinateModel { FirstCityLatitude = 1, FirstCityLongitude = 1, SecondCityLatitude = 1, SecondCityLongitude = 1},0 },
            new object[] { new CoordinateModel { FirstCityLatitude = 73.297975, FirstCityLongitude = 26.372663, SecondCityLatitude = 62.385101, SecondCityLongitude = 41.440440 },1358.98 },
            new object[] { new CoordinateModel { FirstCityLatitude = 83.297975, FirstCityLongitude = 100.372663, SecondCityLatitude = 82.385101, SecondCityLongitude = 61.440440 }, 537.89 }
        };

        [Theory]
        [MemberData(nameof(Coordinates))]
        public async Task Should_Return_GiftAidResponse(CoordinateModel coordinates, double expectedDistance)
        {
            string endPoint = $"api/DistanceCalculator?FirstCityLatitude={coordinates.FirstCityLatitude}" +
                $"&FirstCityLongitude={coordinates.FirstCityLongitude}" +
                $"&SecondCityLatitude={coordinates.SecondCityLatitude}" +
                $"&SecondCityLongitude={coordinates.SecondCityLongitude}";

            var actualDistance = Convert.ToDouble(await _httpClient.GetStringAsync(endPoint));

            Assert.Equal(expectedDistance, actualDistance);
        }

    }
}