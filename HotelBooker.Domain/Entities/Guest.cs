using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooker.Domain.Entities;

/// <summary>
/// A Hotel guest is tied to a booking and room id.
/// </summary>
public class Guest
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string BookingId { get; set; }
    public int RoomId { get; set; }
    [ForeignKey(nameof(BookingId))]
    public Booking Booking { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
}
