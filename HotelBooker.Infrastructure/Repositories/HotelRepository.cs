using HotelBooker.Application.Hotels;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelBooker.Infrastructure.Repositories;
public class HotelRepository : IHotelRepository
{
    private readonly HotelDbContext _context;
    private readonly ILogger<HotelRepository> _logger;
    public HotelRepository(HotelDbContext context, ILogger<HotelRepository> logger)

    {
        _context = context;
        _logger = logger;
    }

    public async Task<string> GetHotelRef(Guid hotelId)
    {
        try
        {
            var hotel = await _context.Hotels
                                          .SingleOrDefaultAsync(h => h.Id == hotelId);

            return hotel.BookingRef;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up Id: {hotelId}");
        }

        return null;
    }
    public async Task<IEnumerable<Hotel>> GetAllLikeName(string name)
    {
        try
        {
            var hotels = await _context.Hotels
                                          .Where(h => h.Name.Contains(name))
                                          .ToListAsync();

            return hotels;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up name: {name}");
        }

        return new List<Hotel>();
    }

    public async Task<IEnumerable<Hotel>> GetAll()
    {
        try
        {
            var hotels = await _context.Hotels.ToListAsync();

            return hotels;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error has occured retrieving all the hotels");
        }

        return new List<Hotel>();
    }
}
