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
    private readonly ISeeder _seeder;
    public HotelController (IHotelService hotelService,
    IRoomTypeService roomTypeService,
    IRoomService roomService,
    ISeeder seeder) 
    {
        _hotelService = hotelService;
        _roomTypeService = roomTypeService;
        _seeder = seeder;
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelsByName([FromQuery]string name)
    {
        var hotel = await _hotelService.GetHotelPreviewsWithName(name);

        return Ok(hotel);
    }

    [HttpGet("{hotelId}/AvailableRooms")]
    public async Task<IActionResult> GetAvailableRooms([FromQuery] AvailableRoomsQuery roomQuery)
    {
        var availableRooms = await _roomService.GetAvailableRooms(roomQuery);

        return Ok(availableRooms);
    }

    [HttpGet("{hotelId}/RoomTypes")]
    public async Task<IActionResult> GetRoomTypes(Guid hotelId)
    {
        var roomTypes = await _roomTypeService.GetRoomTypes(hotelId);

        return Ok(roomTypes);
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
