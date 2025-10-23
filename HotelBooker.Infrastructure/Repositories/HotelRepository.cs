using HotelBooker.Application.Hotels;
using HotelBooker.Application.Logger;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Infrastructure.Repositories;
public class HotelRepository : IHotelRepository
{
    private readonly HotelDbContext _context;
    private readonly ILogger _logger;
    public HotelRepository(HotelDbContext context, ILogger logger)

    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Hotel>> GetAllLikeName(string name)
    {
        try
        {
            var hotels = await _context.Hotels
                                          .Where(h => h.Name.Contains("hello"))
                                          .ToListAsync();

            return hotels;
        }
        catch (Exception e)
        {
            _logger.LogError(e);
        }

        return new List<Hotel>();
    }
}
