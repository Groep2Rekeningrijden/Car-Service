using CarMicroService.DTOs.CarType;

namespace CarMicroService.DTOs.Car
{
    public class UpdateCarDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CarTypeId { get; set; }

        public Guid UserId { get; set; }

    }
}
