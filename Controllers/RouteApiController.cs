using Microsoft.AspNetCore.Mvc;
using VehicleService.DTOs;
using VehicleService.Services;

namespace VehicleService.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteApiController : ControllerBase
{
    private readonly IRouterApiService _routerApiService;

    public RouteApiController(IRouterApiService routerApiService)
    {
        _routerApiService = routerApiService;
    }

    [HttpGet("/vehicle")]
    public async Task<ActionResult<VehicleDto>> GetVehicle(Guid vehicleId)
    {
        var vehicle = await _routerApiService.GetVehicle(vehicleId);
        return vehicle != null ? Ok(vehicle) : NotFound();
    }

    [HttpGet("/get-n")]
    public async Task<ActionResult<VehicleDto>> GetAll(int n)
    {
        var vehicles = await _routerApiService.GetFirstNVehicles(n);
        return vehicles.Any() ? Ok(vehicles) : NotFound();
    }

    [HttpGet("/get-owner")]
    public async Task<ActionResult<VehicleOwnerDto>> GetOwner(Guid vehicleId)
    {
        var vehicleOwner = await _routerApiService.GetVehicleOwner(vehicleId);
        return vehicleOwner != null ? Ok(vehicleOwner) : NotFound();
    }

    [HttpGet("/owned-by")]
    public async Task<ActionResult<VehicleDto>> GetOwnedBy(Guid ownerId)
    {
        var vehicles = await _routerApiService.GetVehiclesWithOwner(ownerId);
        return vehicles.Any() ? Ok(vehicles) : NotFound();
    }

    [HttpGet("/random")]
    public async Task<ActionResult<VehicleDto>> GetRandom()
    {
        var vehicle = await _routerApiService.GetRandomVehicleId();
        return Ok(vehicle);
    }
}