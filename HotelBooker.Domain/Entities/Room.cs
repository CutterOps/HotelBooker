using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooker.Domain.Entities;
public class Room
{
    [Key]
    public int Id { get; set; }

    public string RoomNumber { get; set; }

    public int RoomTypeId { get; set; }

    public int HotelId { get; set; }

    [ForeignKey(nameof(RoomNumber))]
    public Hotel Hotel { get; set; }

    [ForeignKey(nameof(RoomTypeId))]
    public RoomType RoomType { get; set; }

    // Navigation property
    public ICollection<Booking> Bookings { get; private set; } = new List<Booking>();
}
