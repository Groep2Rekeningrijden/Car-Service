using System.ComponentModel.DataAnnotations;

namespace CarMicroService.DTOs.CarType
{
    public class GetCarTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double PricePerKilometer { get; set; }

    }
}
