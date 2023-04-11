using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.CarType;
using CarMicroService.Services.CarTypeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCarTypeDTO>>> GetAllTypes()
        {
            try
            {
                List<GetCarTypeDTO> response = await _carTypeService.GetAllTypes();
                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetCarTypeDTO>> UpdateCarType(UpdateCarTypeDTO dto)
        {
            try
            {
                GetCarTypeDTO response = await _carTypeService.UpdateCarType(dto);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCarType(Guid id)
        {
            try
            {
                await _carTypeService.DeleteCarType(id);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateCarTypeDTO>> CreateCarType(CreateCarTypeDTO dto)
        {
            try
            {
                CreateCarTypeDTO response = await _carTypeService.CreateCarType(dto);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
