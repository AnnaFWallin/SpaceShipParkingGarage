using SpaceshipGarageAPI.Data.Entities;

namespace SpaceshipGarageAPI.Interfaces;

public interface IParkinglotRepository
{
    public ParkingLotEntity GetParkingLot(string id);

    public ParkingLotEntity GetParkingLotByNumberPlate(string carNumberPlate);

    public Task ChangeParkingLotToOccupied(Guid id, string carNumberPlate, DateTime time);

    public Task ChangeParkingLotToUnOccupied(Guid id);
}
