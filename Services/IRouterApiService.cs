using VehicleService.DTOs;

namespace VehicleService.Services;

public interface IRouterApiService
{
    public Task<VehicleDto?> GetVehicle(Guid vehicleId);
    public Task<List<VehicleDto>> GetFirstNVehicles(int n);
    public Task<VehicleOwnerDto?> GetVehicleOwner(Guid vehicleId);
    public Task<List<VehicleDto>> GetVehiclesWithOwner(Guid ownerId);
    public Task<VehicleDto> GetRandomVehicleId();
}