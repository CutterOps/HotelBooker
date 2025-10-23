using HotelBooker.Application.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    public HotelController (IHotelService hotelService) 
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelsByName([FromQuery]string name)
    {
        var hotel = await _hotelService.GetHotelPreviewsWithName(name);

        return Ok(hotel);
    }
}
