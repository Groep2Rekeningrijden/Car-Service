using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMicroService.Model
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("CarType")]
        public int CarTypeId { get; set; }

        public CarType CarType { get; set; }

    }
}
