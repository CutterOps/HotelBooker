using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooker.Domain.Entities;
public class Booking
{
    /// <summary>
    /// This is the Booking Ref
    /// </summary>
    [Key]
    public string Id { get; set; }

    public Guid HotelId { get; set; }

    public Guid CustomerId { get; set; }

    public DateTime Created { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [ForeignKey(nameof(Booking))]
    public Hotel Hotel { get; set; }

    // Navigation property
    public ICollection<Room> Rooms { get; set; }

    public ICollection<Guest> Guests { get; set; }
}
