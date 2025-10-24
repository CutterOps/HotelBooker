namespace HotelBooker.Application.Bookings.Dtos;
public class SelectedRoomsAvailability
{
    public Guid HotelId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public List<RoomAndGuestCapacity> Rooms { get; set; }
}
