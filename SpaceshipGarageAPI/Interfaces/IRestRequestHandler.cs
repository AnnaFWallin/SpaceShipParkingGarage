using SpaceshipGarageAPI.Data;

using SpaceshipGarageAPI.Models;

namespace SpaceshipGarageAPI.Interfaces;

public interface IRestRequestHandler
{
    Task<ParkingLot> ParkSpaceship(string id, string carNumberPlate, DateTime time);
    Task<ParkingBill> UnparkSpaceship(string carNumberPlate, DateTime time);
}
