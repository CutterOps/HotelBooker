using HotelBooker.Application.Hotels;
using HotelBooker.Application.Seeding;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly ISeeder _seeder;
    public HotelController (IHotelService hotelService,
    ISeeder seeder) 
    {
        _hotelService = hotelService;
        _seeder = seeder;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelsByName([FromQuery]string name)
    {
        var hotel = await _hotelService.GetHotelPreviewsWithName(name);

        return Ok(hotel);
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
