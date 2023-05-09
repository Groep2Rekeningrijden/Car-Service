namespace CarMicroService.DTOs.CarType
{
    public class UpdateCarTypeDTO
    {
        public Guid CarTypeId { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public double PricePerKilometer { get; set; }
    }
}
