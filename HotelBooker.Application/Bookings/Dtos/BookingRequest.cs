namespace HotelBooker.Application.Bookings.Dtos;
public class BookingRequest
{
    public Guid HotelId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public List<RoomAndGuests> RoomsAndGuests { get; set; }

}
