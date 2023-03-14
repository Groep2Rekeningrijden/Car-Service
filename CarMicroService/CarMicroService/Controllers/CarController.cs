using CarMicroService.DTOs.Car;
using CarMicroService.Services.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCarDTO>>> getAllCars()
        {
            List<GetCarDTO> res = new List<GetCarDTO>();
            res = await _carService.GetAllCars();
            return Ok(res);
        }
    }
}
