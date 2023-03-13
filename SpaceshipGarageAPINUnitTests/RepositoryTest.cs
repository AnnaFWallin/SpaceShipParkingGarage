using Microsoft.EntityFrameworkCore;
using SpaceshipGarageAPI.Data;
using SpaceshipGarageAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipGarageAPITests;

public class RepositoryTest
{
    private ParkinglotRepository _repository;
    private IDbContextFactory<SpaceshipDbContext> _dbContextFactory; 

    [SetUp]
}
