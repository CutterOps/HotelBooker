namespace HotelBooker.Application.Bookings.Dtos;
public class BookingResult
{
    public Guid HotelId { get; set; }

    public string BookingRef { get; set; }

    public decimal TotalPrice { get; set; }
}
