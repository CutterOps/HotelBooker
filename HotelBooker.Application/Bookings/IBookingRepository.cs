using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Bookings;
public interface IBookingRepository
{
    public Task<string> TryInsertBooking(Booking booking);

    public Task<Booking> GetBooking(string id);
}
