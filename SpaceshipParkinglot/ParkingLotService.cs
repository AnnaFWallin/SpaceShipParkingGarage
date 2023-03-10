namespace SpaceshipParkinglot;

public class ParkingLotService
{
    public static ParkingLot ParkingCar(string id, string carNumberPlate, DateTime time)
    {
        var myLot = parkingLots.FirstOrDefault(x => x.Id == id);

        if (myLot?.Occupied == true)
            throw new Exception("ParkingLot is occupied. Try somewhere else");

        myLot.CarNumberPlate = carNumberPlate;
        myLot.Occupied = true;
        myLot.Timpestamp = time;

        return myLot;
    }

    public static TimeSpan UnparkCar(string carNumberPlate, DateTime time)
    {
        var myCar = parkingLots.FirstOrDefault(x => x.CarNumberPlate == carNumberPlate);

        if (myCar == null)
            throw new Exception("There is no car with that number plate. Try again.");

        var timeParked = time - myCar.Timpestamp;
        myCar.CarNumberPlate = null;
        myCar.Occupied = false;
        myCar.Timpestamp = null;


        Console.WriteLine(timeParked);
        Console.WriteLine("Parking lot: " + myCar.Id + " " + myCar.CarNumberPlate + " " + myCar.Occupied + " " + myCar.Floor + " " + myCar.Timpestamp);

        var cost = ParkingLotCost(timeParked.Value);
        Console.WriteLine("Cost: " + cost + " SEK");

        return timeParked.Value;

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


    public static List<ParkingLot> parkingLots = new()
{
    new ParkingLot { Id = "A01", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A02", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A03", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A04", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A05", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A06", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A07", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A08", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A09", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A10", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A11", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A12", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A13", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A14", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "A15", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B01", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B02", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B03", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B04", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B05", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B06", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B07", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B08", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B09", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B10", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B11", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B12", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B13", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B14", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "B15", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C01", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C02", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C03", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C04", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C05", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C06", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C07", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C08", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C09", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C10", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C11", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C12", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C13", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C14", Floor = 1, Occupied = false   },
    new ParkingLot { Id = "C15", Floor = 1, Occupied = false   }

};
}
