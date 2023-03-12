using Microsoft.AspNetCore.Mvc;
using SpaceshipGarageAPI.Data;
using SpaceshipGarageAPI.Interfaces;
using SpaceshipGarageAPI.Models;

namespace SpaceshipGarageAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingController : ControllerBase
{
    private readonly IRestRequestHandler _restRequestHandler;

    public ParkingController(IRestRequestHandler restRequestHandler)
    {
        _restRequestHandler = restRequestHandler;
    }

    [HttpPut("{parkinglotId}/{numberPlate}")]
    public async Task<ParkingLot> ParkSpaceship(string parkinglotId, string numberPlate)
    {
        return await _restRequestHandler.ParkSpaceship(parkinglotId, numberPlate, DateTime.Now);
    }

    [HttpPut("{numberPlate}")]
    public async Task<ParkingBill> UnparkSpaceship(string numberPlate)
    {
        return await _restRequestHandler.UnparkSpaceship(numberPlate, DateTime.Now);
    }

}
