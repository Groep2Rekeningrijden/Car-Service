using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.CarType;

namespace CarMicroService.Services.CarService
{
    public interface ICarService
    {
        public Task<List<GetCarDTO>> GetAllCars();

        public Task<CreateCarDTO> CreateCar(CreateCarDTO Dto);

        public Task<GetCarDTO> UpdateCar(UpdateCarDTO Dto);

        public Task<bool> DeleteCar(int id);
    }
}
