using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Domain.Entities;
public class Hotel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }

    [MaxLength(5)]
    public string BookingRef { get; set; }

    // Leave these out till they are implemented into Entity Framework
    //public ICollection<Room> Rooms { get; set; }

    //public ICollection<Booking> Bookings { get; set; }
}
