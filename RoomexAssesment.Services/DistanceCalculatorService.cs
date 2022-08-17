using RoomexAssesment.Services.Extension;
using RoomexAssesment.Services.DTO;

namespace RoomexAssesment.Services
{

    public interface IDistanceCalculatorService
    {
        double Calculate(CoordinateDTO coordinates);
    }
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        public double Calculate(CoordinateDTO coordinates)
        {
            const double earthRadius = 6371;
            var a = (90 - coordinates.FirstCityLatitude).ConvertToRadian();
            var b = (90 - coordinates.SecondCityLatitude).ConvertToRadian();
            var c = (coordinates.FirstCityLongitude - coordinates.SecondCityLongitude).ConvertToRadian();
            var cosP = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(c);
            var AcosP = Math.Acos(cosP);
            return Math.Round(earthRadius * AcosP, 2);
        }
    }
}