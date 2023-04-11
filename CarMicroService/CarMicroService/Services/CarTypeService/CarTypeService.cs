using AutoMapper;
using CarMicroService.Data;
using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.CarType;
using CarMicroService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CarMicroService.Services.CarTypeService
{
    public class CarTypeService : ICarTypeService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CarTypeService(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public CarTypeService() { }

        public async Task<List<GetCarTypeDTO>> GetAllTypes()
        {
            List<GetCarTypeDTO> res = new List<GetCarTypeDTO>();

            try
            {
                List<CarType> types = await _dataContext.CarTypes.ToListAsync();

                res = types.Select(t => _mapper.Map<CarType, GetCarTypeDTO>(t)).ToList();
            }
            catch (Exception ex)
            {
                res = null;
            }

            return res;
        }

        public async Task<CreateCarTypeDTO> CreateCarType(CreateCarTypeDTO Dto)
        {
            try
            {
                CarType post = _mapper.Map<CarType>(Dto);

                _dataContext.CarTypes.Add(post);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dto;
        }

        public async Task<GetCarTypeDTO> UpdateCarType(UpdateCarTypeDTO Dto)
        {
            GetCarTypeDTO res = new GetCarTypeDTO();
            try
            {
                CarType? before = _dataContext.Find<CarType>(Dto.Id);

                before.PricePerKilometer = Dto.PricePerKilometer;

                _dataContext.CarTypes.Update(before);
                await _dataContext.SaveChangesAsync();

                res = _mapper.Map<GetCarTypeDTO>(before);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }

        public async Task<bool> DeleteCarType(Guid id)
        {
            try
            {
                _dataContext.Remove(_dataContext.CarTypes.Single(k => k.Id == id));
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
