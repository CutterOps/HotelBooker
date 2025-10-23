using HotelBooker.Application.Rooms;
using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelBooker.Infrastructure.Repositories;
public class RoomRepository : IRoomRepository
{
    private readonly HotelDbContext _context;
    private readonly ILogger<HotelRepository> _logger;
    public RoomRepository(HotelDbContext context, ILogger<HotelRepository> logger)

    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Room>> GetAllAvailableRoomsIncludeRoomType(AvailableRoomsQuery roomsQuery)
    {
        try
        {
            var availableRooms = await _context.Rooms.Include(x => x.Bookings)
                .Include(r => r.RoomType)
                .Where(r => r.HotelId == roomsQuery.HotelId)
                .Where(r => !r.Bookings.Any(b => roomsQuery.StartDate < b.EndDate && b.StartDate < roomsQuery.EndDate) && 
                    roomsQuery.GuestCapacity.Any(requestedCapacity => r.RoomType.GuestCapacity >= requestedCapacity))
                    .ToListAsync();

            return availableRooms;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up Hotel: {roomsQuery.HotelId}");
        }

        return new List<Room>();
    }
}
