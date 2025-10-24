using HotelBooker.Application.Rooms.Dtos;

namespace HotelBooker.Application.Rooms;
public interface IRoomService
{
    Task<RoomAvailabilityResult> GetAvailableRooms(AvailableRoomsQuery query);
}
