using HotelBooker.Application.Bookings;
using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Application.Hotels;
using HotelBooker.Application.Rooms;
using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Application.Seeding;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IRoomTypeService _roomTypeService;
    private readonly IRoomService _roomService;
    private readonly IBookingService _bookingService;
    private readonly ISeeder _seeder;
    public HotelController (IHotelService hotelService,
    IRoomTypeService roomTypeService,
    IRoomService roomService,
    IBookingService bookingService,
    ISeeder seeder) 
    {
        _hotelService = hotelService;
        _roomTypeService = roomTypeService;
        _seeder = seeder;
        _roomService = roomService;
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelsByName([FromQuery]string? name)
    {
        var hotel = await _hotelService.GetHotelPreviewsWithName(name);

        return Ok(hotel);
    }

    [HttpGet("{hotelId}/AvailableRooms")]
    public async Task<IActionResult> GetAvailableRooms([FromRoute] Guid hotelId, [FromQuery] AvailableRoomsQuery roomQuery)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // I hate this. This is awful. I should make models in the Api.
        roomQuery.HotelId = hotelId;
        var availableRooms = await _roomService.GetAvailableRooms(roomQuery);

        return Ok(availableRooms);
    }

    [HttpGet("{hotelId}/RoomTypes")]
    public async Task<IActionResult> GetRoomTypes([FromRoute]Guid hotelId)
    {
        var roomTypes = await _roomTypeService.GetRoomTypes(hotelId);

        return Ok(roomTypes);
    }

    [HttpGet("{hotelId}/BookingRequest")]
    public async Task<IActionResult> RequestBooking([FromRoute] Guid hotelId, [FromQuery] BookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        request.HotelId = hotelId;

        
        var result = await _bookingService.RequestBooking(request);

        return Ok(result);
    }


    [HttpDelete("ResetData")]
    public async Task<IActionResult> ResetData()
    {
        var result = await _seeder.ResetData();

        if (result)
        {
            return Ok();
        }
        else
        {
            // Internall something went wrong.
            return StatusCode(500);
        }
    }
    [HttpPost("SeedData")]
    public async Task<IActionResult> SeedData()
    {
        var result = await _seeder.SeedData();

        if (result)
        {
            return Ok();
        }
        else
        {
            // Internall something went wrong.
            return StatusCode(500);
        }
    }
}
