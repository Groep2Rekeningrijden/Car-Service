namespace VehicleService.DTOs;

public class VehicleDto
{
    public VehicleDto(Guid id, string licence, string classification, string fuelType)
    {
        Id = id;
        Classification = classification;
        FuelType = fuelType;
        Licence = licence;
    }

    public Guid Id { get; set; }
    public string Licence { get; set; }

    public string Classification { get; set; }

    public string FuelType { get; set; }
}