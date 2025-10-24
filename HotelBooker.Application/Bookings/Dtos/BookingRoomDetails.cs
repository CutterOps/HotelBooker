namespace HotelBooker.Application.Bookings.Dtos;
public class BookingRoomDetails
{
    public string RoomTypeName { get; set; }

    public decimal TotalPrice { get; set; }

    public List<RoomGuest> Guests { get; set; }
}
