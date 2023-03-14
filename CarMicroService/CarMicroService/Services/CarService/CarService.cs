using AutoMapper;
using CarMicroService.Data;
using CarMicroService.DTOs.Car;
using CarMicroService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarMicroService.Services.Car
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
                List<CarModel> Cars = await _dataContext.Cars.ToListAsync();

                response = Cars.Select(t => _mapper.Map<CarModel, GetCarDTO>(t)).ToList();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }


    }
}
