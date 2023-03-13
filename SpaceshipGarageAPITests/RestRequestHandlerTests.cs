using SpaceshipGarageAPI.Interfaces;
using SpaceshipGarageAPI.RequestHandlers;
using Xunit;
using System;
using Autofac.Extras.Moq;
using SpaceshipGarageAPI.Data.Entities;
using Moq;
using SpaceshipGarageAPI.Models;
using System.Drawing;
using SpaceshipGarageAPI.Data;
using SpaceshipGarageAPI.Data.Repository;

namespace SpaceshipGarageAPITests;

public class RestRequestHandlerTests
{

    [Fact]
    public void ParkingLotCost_should_return_double()
    {
    }


    [Fact]
    public void ParkSpaceship_should_change_occupied_to_true()
    {
        using (var mock = AutoMock.GetLoose())
        {
            mock.Mock<IParkinglotRepository>()
                .Setup(x => x.GetParkingLot(It.IsAny<string>()))
                .Returns(GetParkingLot());

            var handler = mock.Create<IRestRequestHandler>();

            var expected = GetParkingLot();

            var parkingLotId = "A03";
            var numberPlate = "ABC654";
            var time = DateTime.Now;

            var actual = handler.ParkSpaceship(parkingLotId, numberPlate, time);

            Assert.IsType<ParkingLot>(actual);

        }
        //var lot = await _sut.ParkSpaceship(parkingLotId, numberPlate, time);

        //lot.Occupied.Equals(true);
        
    }

    private ParkingLotEntity GetParkingLot()
    {
        return new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A03", Floor = 1, Occupied = false };
    }

    private List<ParkingLotEntity> GetParkinglots()
    {
        List<ParkingLotEntity> output = new List<ParkingLotEntity>
        {
            new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A01", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A02", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A03", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A04", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A05", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A06", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A07", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A08", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A09", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A10", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A11", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A12", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A13", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A14", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A15", Floor = 1, Occupied = false },
        new ParkingLotEntity { Id = Guid.NewGuid(), Name = "B01", Floor = 1, Occupied = false }
        };
        
        return output;
}

    //private IParkinglotRepository _repository;
    //private RestRequestHandler _sut;

    //public RestRequestHandlerTests()
    //{
    //    _sut = new RestRequestHandler(_repository);
    //}
    //public void Dispose()
    //{
    //    throw new NotImplementedException();
    //}
}