namespace HotelBooker.Application.Rooms.Dtos;
public class AvailableRoom
{
    public int RoomId { get; set; }

    public string RoomTypeName { get; set; }

    /// <summary>
    /// How many can fit in the room
    /// </summary>
    public int RoomGuestCapacity { get; set; }

    public decimal PricePerNight { get; set; }
}
