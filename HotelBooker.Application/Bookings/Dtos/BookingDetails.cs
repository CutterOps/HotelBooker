namespace HotelBooker.Application.Bookings.Dtos;
public class BookingDetails
{
    public string HotelName { get; set; }

    public decimal TotalPrice { get; set; }

    public int TotalNights { get; set; }

    public List<BookingRoomDetails> RoomDetails { get; set; }
}
