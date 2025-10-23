namespace HotelBooker.Application.Rooms.Dtos;
public class RoomAvailabilityResult
{
    public Guid HotelId { get; set; }

    public List<AvailableRoom> AvailableRooms { get; set; } = new List<AvailableRoom>();
}
