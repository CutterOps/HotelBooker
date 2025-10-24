using HotelBooker.Application.Bookings.Dtos;

namespace HotelBooker.Application.Bookings;
public interface IBookingService
{
    public Task<string> RequestBooking(BookingRequest request);

    public Task<BookingDetails> GetBookingDetails(string bookingId);
}
