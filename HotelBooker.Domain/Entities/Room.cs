using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooker.Domain.Entities;
public class Room
{
    [Key]
    public int Id { get; set; }
    

    /// <summary>
    /// The Database size matters. This could have Max length and many others could too.
    /// </summary>
    public string RoomNumber { get; set; }

    public int RoomTypeId { get; set; }

    public Guid HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; }

    [ForeignKey(nameof(RoomTypeId))]
    public RoomType RoomType { get; set; }

    // This could help allow hotels consider which rooms are being booked more or less...
    public ICollection<Booking> Bookings { get; private set; } = new List<Booking>();
}
