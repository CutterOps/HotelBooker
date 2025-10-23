using HotelBooker.Application.RoomTypes;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelBooker.Infrastructure.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly HotelDbContext _context;
    private readonly ILogger<HotelRepository> _logger;
    public RoomTypeRepository(HotelDbContext context, ILogger<HotelRepository> logger)

    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<RoomType>> GetAllRoomsByHotelId(Guid hotelId)
    {
        try
        {
            var roomTypes = await _context.RoomTypes
                                          .Where(r => r.HotelId == hotelId)
                                          .ToListAsync();

            return roomTypes;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up HotelId: {hotelId}");
        }

        return new List<RoomType>();
    }
}
