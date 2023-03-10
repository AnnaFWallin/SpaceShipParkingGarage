using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceshipParkinglot;

public class ParkingLot
{
    public string Id { get; set; }
    public int Floor { get; set; }
    public bool Occupied { get; set; }
    public string? CarNumberPlate { get; set; }
    public DateTime? Timpestamp { get; set; }
}
