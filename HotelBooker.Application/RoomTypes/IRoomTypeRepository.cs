using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.RoomTypes;
public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAllRoomsByHotelId(Guid hotelId);
}
