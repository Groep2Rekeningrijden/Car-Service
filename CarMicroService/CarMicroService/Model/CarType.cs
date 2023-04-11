using System.ComponentModel.DataAnnotations;

namespace CarMicroService.Model
{
    public class CarType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double PricePerKilometer { get; set; }   

    }
}
