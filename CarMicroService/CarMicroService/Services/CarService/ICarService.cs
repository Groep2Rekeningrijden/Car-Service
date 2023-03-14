using CarMicroService.DTOs.Car;

namespace CarMicroService.Services.Car
{
    public interface ICarService
    {
        public Task<List<GetCarDTO>> GetAllCars();


    }
}
