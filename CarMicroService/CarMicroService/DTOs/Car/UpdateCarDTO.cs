using CarMicroService.DTOs.CarType;

namespace CarMicroService.DTOs.Car
{
    public class UpdateCarDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CarTypeId { get; set; }

    }
}
