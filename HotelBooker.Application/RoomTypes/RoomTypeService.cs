using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Application.RoomTypes;
using System.Runtime.CompilerServices;

namespace HotelBooker.Application.Rooms;
public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;

    public RoomTypeService(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<List<RoomTypeDetails>> GetRoomTypes(Guid hotelId)
    {
        var roomTypes = await _roomTypeRepository.GetAllRoomsByHotelId(hotelId);

        return roomTypes.Select(r => new RoomTypeDetails()
        {
            Id = r.Id,
            Name = r.Name,
            GuestCapacity = r.GuestCapacity
        }).ToList();
    }
}
