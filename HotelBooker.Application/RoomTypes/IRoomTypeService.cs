using HotelBooker.Application.Rooms.Dtos;

namespace HotelBooker.Application.Rooms;
public interface IRoomTypeService
{
    Task<List<RoomTypeDetails>> GetRoomTypes(Guid hotelId);
}
