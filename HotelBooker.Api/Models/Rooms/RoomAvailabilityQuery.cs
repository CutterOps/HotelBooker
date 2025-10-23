namespace HotelBooker.Api.Models.Rooms;

public class RoomAvailabilityQuery
{
    public Guid HotelId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public RoomCapacity[] RequiredRooms { get; set; }
}