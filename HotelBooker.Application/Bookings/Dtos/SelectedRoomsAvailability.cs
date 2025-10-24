namespace HotelBooker.Application.Bookings.Dtos;
public class SelectedRoomsAvailability : DateRangeDto
{
    public Guid HotelId { get; set; }

    public List<int> RoomIds { get; set; }
}
