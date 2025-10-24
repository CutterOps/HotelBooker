using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Rooms;
public interface IRoomRepository
{
    Task<List<Room>> GetAllAvailableRoomsIncludeRoomType(AvailableRoomsQuery roomsQuery);

    /// <summary>
    /// Could be better ways of doing this but its killing 2 birds with 1 stone. 
    /// Check if the rooms are available between the 2 dates if they are then return the price total
    /// If not it returns null.
    /// </summary>
    /// <returns></returns>
    Task<List<Room>> GetSelectedAvailableRooms(SelectedRoomsAvailability selectedRooms);
}
