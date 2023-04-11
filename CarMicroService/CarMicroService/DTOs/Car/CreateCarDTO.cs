using CarMicroService.DTOs.CarType;

namespace CarMicroService.DTOs.Car
{
    public class CreateCarDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CarTypeId { get; set; }

        public Guid UserId { get; set; }
    }
}
