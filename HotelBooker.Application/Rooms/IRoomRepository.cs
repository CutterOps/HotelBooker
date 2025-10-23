using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Rooms;
public interface IRoomRepository
{
    Task<List<Room>> GetAllAvailableRoomsIncludeRoomType(AvailableRoomsQuery roomsQuery);
}
