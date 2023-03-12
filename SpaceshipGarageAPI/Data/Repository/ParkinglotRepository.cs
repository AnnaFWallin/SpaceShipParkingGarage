using Microsoft.EntityFrameworkCore;
using SpaceshipGarageAPI.Data.Entities;
using SpaceshipGarageAPI.Interfaces;

namespace SpaceshipGarageAPI.Data.Repository;

public class ParkinglotRepository : IParkinglotRepository
{
    private readonly SpaceshipDbContext _dbContext;
    public ParkinglotRepository(SpaceshipDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public ParkingLotEntity GetParkingLot(string id)
    {
        var lot = _dbContext.ParkingLots.FirstOrDefault(x => x.Name == id);

        if (lot == null)
            throw new Exception("This parking lot id is invalid.");

        return lot;
    }

    public ParkingLotEntity GetParkingLotByNumberPlate(string carNumberPlate)
    {
        var lot = _dbContext.ParkingLots.FirstOrDefault(x => x.CarNumberPlate == carNumberPlate);

        if (lot == null)
            throw new Exception("The number plate is not registered on any parkinglot.");

        return lot;
    }

    public async Task ChangeParkingLotToOccupied(Guid id, string carNumberPlate, DateTime time)
    {
        var lot = await _dbContext.ParkingLots.FirstOrDefaultAsync(x => x.Id == id);

        if (lot == null)
            throw new Exception("Invalid id.");

        lot.Occupied = true;
        lot.CarNumberPlate = carNumberPlate;
        lot.Timpestamp = time;
        await _dbContext.SaveChangesAsync();
    }

    public async Task ChangeParkingLotToUnOccupied(Guid id)
    {
        var lot = await _dbContext.ParkingLots.FirstOrDefaultAsync(x => x.Id == id);

        if (lot == null)
            throw new Exception("Invalid id.");

        lot.Occupied = false;
        lot.CarNumberPlate = null;
        lot.Timpestamp = null;
        await _dbContext.SaveChangesAsync();
    }

    public static double ParkingLotCost(TimeSpan time)
    {
        double cost24hours = 50;
        double cost1hour = 15;

        double x = time.Days * cost24hours;
        double y = time.Hours * cost1hour;
        double z = ((double)time.Minutes / 60) * cost1hour;

        double total = x + y + z;
        return total;
    }        
}
