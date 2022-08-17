using AutoMapper;
using RoomexAssesment.API.Model;
using RoomexAssesment.Services.DTO;

namespace RoomexAssesment.API.Automapper
{
    public class CoordinateModelToCoordinateDTO:Profile
    {
        public CoordinateModelToCoordinateDTO()
        {
            CreateMap<CoordinateModel, CoordinateDTO>();
        }
    }
}
