using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooker.Domain.Entities;

public class RoomType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public Guid HotelId { get; set; }

    /// <summary>
    /// How many people can sleep in the room.
    /// </summary>
    public int GuestCapacity { get; set; }

    public decimal PricePerNight { get; set; }

    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; }

    public ICollection<Room> Rooms { get; set; }
}
