using SpaceshipGarageAPI.Data;
using SpaceshipGarageAPI.Interfaces;
using SpaceshipGarageAPI.Models;

namespace SpaceshipGarageAPI.RequestHandlers;

public class RestRequestHandler : IRestRequestHandler
{
    private readonly IParkinglotRepository _parkinglotRepository;

    public RestRequestHandler(IParkinglotRepository parkinglotRepository)
    {
        _parkinglotRepository = parkinglotRepository;
    }

    public async Task<ParkingLot> ParkSpaceship(string id, string carNumberPlate, DateTime time)
    {
        var lot = _parkinglotRepository.GetParkingLot(id);
        if (lot == null)
            throw new Exception("Invalid id.");
        if (lot?.Occupied == true)
            throw new Exception("ParkingLot is occupied.");

        await _parkinglotRepository.ChangeParkingLotToOccupied(lot.Id, carNumberPlate, time);

        var parkingLot = new ParkingLot
        {
            Id = lot.Name,
            Floor = lot.Floor,
            Occupied = lot.Occupied,
            CarNumberPlate = lot.CarNumberPlate,
            Timpestamp = lot.Timpestamp,
        };

        return parkingLot;
    }

    public async Task<ParkingBill> UnparkSpaceship(string carNumberPlate, DateTime time)
    {
        var lot = _parkinglotRepository.GetParkingLotByNumberPlate(carNumberPlate);
        if (lot == null)
            throw new Exception("Invalid id.");

        var timeParked = time - lot.Timpestamp;
        await _parkinglotRepository.ChangeParkingLotToUnOccupied(lot.Id);

        return new ParkingBill
        {
            Id = Guid.NewGuid(),
            NumberPlate = carNumberPlate,
            Cost = ParkingLotCost(timeParked.Value),
            TimeParked = timeParked.ToString() 
        };
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
