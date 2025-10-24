using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Application.Rooms;
using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            var availableRoomsQueryable = GetAvailableRoomsQueryable(roomsQuery.HotelId, roomsQuery.StartDate, roomsQuery.EndDate);
            var availableRooms = await availableRoomsQueryable.Where(r => roomsQuery.GuestCapacity.Any(requestedCapacity => r.RoomType.GuestCapacity >= requestedCapacity))
                    .ToListAsync();

            return availableRooms;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up Hotel: {roomsQuery.HotelId}");
        }

        return new List<Room>();
    }

    public async Task<List<Room>> GetSelectedAvailableRooms(SelectedRoomsAvailability selectedRooms)
    {
        try
        {
            var availableRooms = await GetAvailableRoomsQueryable(selectedRooms.HotelId, selectedRooms.StartDate, selectedRooms.EndDate)
                .Where(r => selectedRooms.RoomIds.Contains(r.Id)).ToListAsync();

            // If the available rooms is missing any of the selected rooms we needed.
            var availableRoomIds = availableRooms.Select(r => r.Id).ToList();
            var anyMissingRooms = availableRoomIds.Except(availableRoomIds).ToList();

            if (anyMissingRooms.Count > 0)
            {
                return null;
            }

            return availableRooms;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error has occured looking up Hotel: {selectedRooms.HotelId}");
        }

        return null;
    }

    private IQueryable<Room> GetAvailableRoomsQueryable(Guid hotelId, DateOnly startDate, DateOnly endDate)
    {
        return _context.Rooms.Include(r => r.Bookings)
                .Include(r => r.RoomType)
                .Where(r => r.HotelId == hotelId && !r.Bookings.Any(b => startDate < b.EndDate && b.StartDate < endDate));
    }
}
