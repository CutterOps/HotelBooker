namespace HotelBooker.Application.Bookings.Dtos;
public class RoomAndGuests
{
    public int RoomId { get; set; }

    public List<RoomGuest> Guests { get; set; } 
}
