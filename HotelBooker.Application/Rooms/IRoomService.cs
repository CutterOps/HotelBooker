using HotelBooker.Application.Rooms.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooker.Application.Rooms;
public interface IRoomService
{
    Task<RoomAvailabilityResult> GetAvailableRooms(AvailableRoomsQuery query);
}
