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
            _logger.LogError(e, $"Error has occur looking up name: {name}");
        }

        return new List<Hotel>();
    }
}
