using SpaceshipGarageAPI.RequestHandlers;
using SpaceshipParkinglot;

namespace SpaceshipGarageAPITests;

public class RestRequestHandlerTests
{
    private ParkinglotRepository _parkinglotRepository;

    public RestRequestHandlerTests(ParkinglotRepository parkinglotRepository)
    {
        _parkinglotRepository = parkinglotRepository;
    }

    [Fact]
    public async Task ParkSpaceship_should_change_occupied_to_true()
    {
        var handler = new RestRequestHandler(_parkinglotRepository);
        var parkingLotId = "B02";
        var numberPlate = "ABC654";
        var time = DateTime.Now;
        var lot = await handler.ParkSpaceship(parkingLotId, numberPlate, time);

        lot.Occupied.Equals(true);
        
    }
}