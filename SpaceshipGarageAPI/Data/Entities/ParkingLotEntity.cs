using System.ComponentModel.DataAnnotations;

namespace SpaceshipGarageAPI.Data.Entities;

public class ParkingLotEntity
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Floor { get; set; }
    [Required]
    public bool Occupied { get; set; }
    public string? CarNumberPlate { get; set; }
    public DateTime? Timpestamp { get; set; }
}
