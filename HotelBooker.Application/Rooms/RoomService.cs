using HotelBooker.Application.Rooms.Dtos;

namespace HotelBooker.Application.Rooms;
public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    { 
        _roomRepository = roomRepository;
    }
    public async Task<RoomAvailabilityResult> GetAvailableRooms(AvailableRoomsQuery query)
    {
        var availableRooms = await _roomRepository.GetAllAvailableRoomsIncludeRoomType(query);

        var roomsDto = availableRooms.Select(r => new AvailableRoom()
        {
            RoomId = r.Id,
            RoomTypeName = r.RoomType.Name,
            PricePerNight = r.RoomType.PricePerNight,
            RoomGuestCapacity = r.RoomType.GuestCapacity,
        }).ToList();

        return new RoomAvailabilityResult()
        {
            AvailableRooms = roomsDto,
            HotelId = query.HotelId
        };
    }
}
