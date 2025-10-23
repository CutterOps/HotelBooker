using HotelBooker.Application.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.Api.Controllers;

[ApiController]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    public HotelController (IHotelService hotelService) 
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelsByName(string name)
    {
        var hotel = await _hotelService.GetHotelPreviewsWithName(name);

        return Ok(hotel);
    }
}
