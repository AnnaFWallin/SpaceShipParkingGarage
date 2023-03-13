using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using SpaceshipGarageAPI.Data.Entities;
using SpaceshipGarageAPI.Data.Repository;
using SpaceshipGarageAPI.Interfaces;
using SpaceshipGarageAPI.RequestHandlers;
using SpaceshipGarageAPI.Data;

namespace SpaceshipGarageAPINUnitTests;


public class RestRequestHandlerTests
{
    //private IParkinglotRepository _repository;
    //private Mock<IParkinglotRepository> _mockRepository;
    //private Fixture _fixture;


    private RestRequestHandler _sut;
    private IParkinglotRepository _parkinglotRepository;


    [SetUp]
    public void Setup()
    {
        ////MochParkinglotRepository();
        //_fixture= new Fixture();
        //_mockRepository = new Mock<IParkinglotRepository>();
        //_sut = new RestRequestHandler();

        _parkinglotRepository = Substitute.For<IParkinglotRepository>();
        _sut = new RestRequestHandler(_parkinglotRepository);
    }

    [Test]
    public async Task Testing()
    {
        var name = "A11";
        var numberplate = "ABC";
        var time = DateTime.Now;

        var lot = await _sut.ParkSpaceship(name, numberplate, time);

        lot.Should().NotBeNull();
    }

    //[Test]
    //public void ParkingLotCost_should_return_double()
    //{
    //    _sut.par
    //}

    //[Test]
    //public async Task ParkSpaceship_should_change_occupied_to_true()
    //{
    //    var parkingLot = _fixture.Create<ParkingLotEntity>();

    //    _mockRepository.Setup(repo => repo.GetParkingLot(It.IsAny<string>()).Returns(parkingLot));

    //    _sut = new RestRequestHandler(_mockRepository.Object);          

    //    var numberPlate = "ABC123";
    //    var time = DateTime.Now.AddDays(-1).AddHours(-2);

    //    //var emptyLot = parkingLots.FirstOrDefault(x => x.Occupied == false);



    //    var result = await _sut.ParkSpaceship(parkingLot.Name, numberPlate, time);

    //    result.Occupied.Equals(true);
    //    Assert.Pass();
    //}

    //private void MochParkinglotRepository()
    //{
    //    //var parkinglots = new List<ParkingLotEntity>();
    //    _repository = Substitute.For<IParkinglotRepository>();
    //    _repository.ChangeParkingLotToOccupied(default, default, default);
    //    _repository.ChangeParkingLotToUnOccupied(default);





    //{
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A01", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A02", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A03", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A04", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A05", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A06", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A07", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A08", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A09", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A10", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A11", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A12", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A13", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A14", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "A15", Floor = 1, Occupied = false };
    //    new ParkingLotEntity { Id = Guid.NewGuid(), Name = "B01", Floor = 1, Occupied = false };


    //};

    //}

    //private ParkingLotEntity GetParkingLot()
    //{
    //    return new ParkingLotEntity() { Id = Guid.NewGuid(), Name = "A04", Floor = 1, Occupied = false };
    //}
}