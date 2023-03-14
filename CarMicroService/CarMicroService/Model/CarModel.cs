using System.ComponentModel.DataAnnotations;

namespace CarMicroService.Model
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }     

    }
}
