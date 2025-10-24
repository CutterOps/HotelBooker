using HotelBooker.Application.Bookings;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

    public async Task<string> TryInsertBooking(Booking booking)
    {
        try
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            if (booking.Id != null)
                return booking.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting booking");
        }
        return null;
    }

    public async Task<Booking> GetBooking(string id)
    {
        try
        {
            return await _context.Bookings.Include(b => b.Rooms)
                    .ThenInclude(r => r.RoomType)
                .Include(h => h.Hotel)
                .Include(b => b.Guests)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving booking Id: {id}");
        }

        return null;
    }
}
