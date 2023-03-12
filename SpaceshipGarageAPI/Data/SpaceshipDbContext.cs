using Microsoft.EntityFrameworkCore;
using SpaceshipGarageAPI.Data.Entities;

namespace SpaceshipGarageAPI.Data;

public class SpaceshipDbContext : DbContext
{
    public SpaceshipDbContext(DbContextOptions<SpaceshipDbContext> options) : base(options) { }
    protected SpaceshipDbContext() { }

    public DbSet<ParkingLotEntity> ParkingLots { get; set;}

}
