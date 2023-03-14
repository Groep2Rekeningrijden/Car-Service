using AutoMapper;
using CarMicroService.DTOs.Car;
using CarMicroService.Model;
using static System.Net.Mime.MediaTypeNames;

namespace CarMicroService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarModel, GetCarDTO>();
        }
    }
}
