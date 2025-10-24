using HotelBooker.Application.Bookings.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Application.Rooms.Dtos;
public class AvailableRoomsQuery
{
    public Guid HotelId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int[] GuestCapacity { get; set; }
}
