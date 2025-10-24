using HotelBooker.Api.Models;
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
    public async Task<IActionResult> GetAvailableRooms([FromRoute] Guid hotelId, [FromQuery] AvailableRoomsModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var availableRooms = await _roomService.GetAvailableRooms(new AvailableRoomsQuery() 
        {
            HotelId = hotelId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            GuestCapacity = model.GuestCapacity
        });

        return Ok(availableRooms);
    }

    [HttpGet("{hotelId}/RoomTypes")]
    public async Task<IActionResult> GetRoomTypes([FromRoute]Guid hotelId)
    {
        var roomTypes = await _roomTypeService.GetRoomTypes(hotelId);

        return Ok(roomTypes);
    }

    /// <summary>
    /// This can be designed in different ways. We could keep the HotelId as part of the query in Gets and put it in the body as well.
    /// </summary>
    [HttpPost("{hotelId}/BookingRequest")]
    public async Task<IActionResult> RequestBooking([FromRoute] Guid hotelId, [FromBody] BookingModel request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        var result = await _bookingService.RequestBooking(new BookingRequest()
        {
            HotelId = hotelId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RoomsAndGuests = request.RoomAndGuests
        });

        return Ok(result);
    }

    /// <summary>
    /// Should be in a separate controller... could then have /BookingRequest as /Booking/Request and put hotelid as part of the body.
    /// Just showing variation.
    /// </summary>
    [HttpGet("~/Booking/{bookingId}")]
    public async Task<IActionResult> GetBooking([FromRoute] string bookingId)
    {
        return Ok(await _bookingService.GetBookingDetails(bookingId));
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
