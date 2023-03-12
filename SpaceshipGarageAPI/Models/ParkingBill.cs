namespace SpaceshipGarageAPI.Models;

public class ParkingBill
{
    public Guid Id { get; set; }
    public string NumberPlate { get; set; }
    public double Cost { get; set; }
    public string TimeParked { get; set; }

}
