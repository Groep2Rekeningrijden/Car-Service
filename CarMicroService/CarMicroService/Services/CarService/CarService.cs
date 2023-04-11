using AutoMapper;
using CarMicroService.Data;
using CarMicroService.DTOs.Car;
using CarMicroService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarMicroService.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CarService(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public async Task<List<GetCarDTO>> GetAllCars()
        {
            List<GetCarDTO> response = new List<GetCarDTO>();

            try
            {
                List<Car> Cars = await _dataContext.Cars.Include(i => i.CarType).ToListAsync();

                response = Cars.Select(t => _mapper.Map<Car, GetCarDTO>(t)).ToList();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public async Task<CreateCarDTO> CreateCar(CreateCarDTO Dto)
        {
            try
            {
                Car post = _mapper.Map<Car>(Dto);

                _dataContext.Cars.Add(post);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Dto;
        }

        public async Task<GetCarDTO> UpdateCar(UpdateCarDTO Dto)
        {
            GetCarDTO res = new();

            try
            {
                Car? before = _dataContext.Find<Car>(Dto.Id);

                before.Name = Dto.Name;
                before.Description = Dto.Description;
                before.CarTypeId = Dto.CarTypeId;

                _dataContext.Cars.Update(before);
                await _dataContext.SaveChangesAsync();

                res = _mapper.Map<GetCarDTO>(before);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            try
            {
                _dataContext.Remove(_dataContext.Cars.Single(k => k.Id == id));
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
