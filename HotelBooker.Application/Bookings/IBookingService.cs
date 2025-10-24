using HotelBooker.Application.Bookings.Dtos;

namespace HotelBooker.Application.Bookings;
public interface IBookingService
{
    public Task<bool> RequestBooking(BookingRequest request); 
}
