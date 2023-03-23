using CarMicroService.DTOs.Car;
using CarMicroService.DTOs.Car;
using CarMicroService.Services.CarService;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace CarMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _CarService;

        public CarController(ICarService carService)
        {
            _CarService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCarDTO>>> GetAllCars()
        {
            try
            {
                List<GetCarDTO> res = new List<GetCarDTO>();
                res = await _CarService.GetAllCars();
                if (res.Count == 0) throw new Exception();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound();
            }         
        }

        [HttpPut]
        public async Task<ActionResult<GetCarDTO>> UpdateCar(UpdateCarDTO dto)
        {
            try
            {
                GetCarDTO response = await _CarService.UpdateCar(dto);
                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCar(int id)
        {
            try
            {
                await _CarService.DeleteCar(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateCarDTO>> CreateCar(CreateCarDTO dto)
        {
            try
            {
                CreateCarDTO response = await _CarService.CreateCar(dto);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("/rabbitMq")]
        public async Task<ActionResult<string>> rabbitMq()
        {
            IConnectionFactory factory = new ConnectionFactory { HostName = "localhost", Port = 5672, UserName = "myuser", Password = "mypassword" };
            using (IConnection connection = factory.CreateConnection())
            {
                IModel channel = connection.CreateModel();

                channel.ExchangeDeclare("test", ExchangeType.Topic, true);

                string message = "Hello World!";
                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("test", "demo", null, body);
            }       
            return "succesfull message";
        }
    }
}
