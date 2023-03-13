using Microsoft.EntityFrameworkCore;
using Npgsql;
using SpaceshipGarageAPI.Data;
using System;

namespace SpaceshipGarageAPIUNitTests;

public class TestDbContextFactory : IDbContextFactory<SpaceshipDbContext>
{
    const string DATABASE_NAME_ENV_VARIABLE = "DatabaseOptions__DatabaseName";
    const string DB_OWNER_USERNAME_ENV_VARIABLE = "DatabaseOptions__Username";
    const string DB_OWNER_PASSWORD_ENV_VARIABLE = "DatabaseOptions__Password";

    private readonly DbContextOptions<SpaceshipDbContext> _dbOptions;

    public TestDbContextFactory()
    {
        var env = Environment.GetEnvironmentVariables();
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder()
        {
            Host = "localhost",
            Username = Environment.GetEnvironmentVariable(DB_OWNER_USERNAME_ENV_VARIABLE),
            Password = Environment.GetEnvironmentVariable(DB_OWNER_PASSWORD_ENV_VARIABLE),
            Database = Environment.GetEnvironmentVariable(DATABASE_NAME_ENV_VARIABLE)
        };

        var dbOptionsBuilder = new DbContextOptionsBuilder<SpaceshipDbContext>()
                .UseNpgsql(connectionStringBuilder.ConnectionString);

        _dbOptions = dbOptionsBuilder.Options;
    }
    public SpaceshipDbContext CreateDbContext()
    {
        throw new SpaceshipDbContext(_dbOptions);
    }
}