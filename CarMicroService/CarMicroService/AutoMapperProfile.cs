using AutoMapper;
using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.CarType;
using CarMicroService.Model;
using static System.Net.Mime.MediaTypeNames;

namespace CarMicroService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, GetCarDTO>();
            CreateMap<Car, CreateCarDTO>();

            CreateMap<CarType, GetCarTypeDTO>();
            CreateMap<CarType, CreateCarTypeDTO>();
            
            CreateMap<CreateCarTypeDTO, CarType>();
            CreateMap<CreateCarDTO, Car>();
        }
    }
}
