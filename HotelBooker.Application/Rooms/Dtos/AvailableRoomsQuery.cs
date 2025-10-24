using HotelBooker.Application.Bookings.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Application.Rooms.Dtos;
public class AvailableRoomsQuery : DateRangeDto
{
    public Guid HotelId { get; set; }
    public int[] GuestCapacity { get; set; }
}
