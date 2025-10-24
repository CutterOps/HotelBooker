using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Bookings;
public interface IBookingRepository
{
    public Task<bool> TryInsertBooking(Booking booking);
}
