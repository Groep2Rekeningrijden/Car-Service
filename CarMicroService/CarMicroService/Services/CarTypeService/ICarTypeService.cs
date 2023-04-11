using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.CarType;

namespace CarMicroService.Services.CarTypeService
{
    public interface ICarTypeService
    {
        public Task<List<GetCarTypeDTO>> GetAllTypes();

        public Task<CreateCarTypeDTO> CreateCarType(CreateCarTypeDTO Dto);

        public Task<GetCarTypeDTO> UpdateCarType(UpdateCarTypeDTO Dto);

        public Task<bool> DeleteCarType(Guid id);
    }
}
