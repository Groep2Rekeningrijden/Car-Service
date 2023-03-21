namespace CarMicroService.DTOs.CarType
{
    public class CreateCarTypeDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double PricePerKilometer { get; set; }
    }
}
