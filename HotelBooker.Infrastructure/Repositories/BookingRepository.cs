using HotelBooker.Application.Bookings;
using HotelBooker.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace HotelBooker.Infrastructure.Repositories;
public class BookingRepository: IBookingRepository
{
    private readonly HotelDbContext _context;
    private readonly ILogger<HotelRepository> _logger;
    public BookingRepository(HotelDbContext context, ILogger<HotelRepository> logger)

    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> TryInsertBooking(Booking booking)
    {
        try
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting booking");
            return false;
        }
    }
}
