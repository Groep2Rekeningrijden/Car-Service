using System.ComponentModel.DataAnnotations;

namespace CarMicroService.Model
{
    public class CarUser
    {
        [Key]
        Guid UserId { get; set; }
        [Key]
        Guid CarId { get; set; }
    }
}
