using HotelBooker.Application.Hotels.Dtos;

namespace HotelBooker.Application.Hotels;
public class HotelService : IHotelService
{
    private readonly IHotelService _hotelService;

    public HotelService(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public async Task<List<HotelPreviewDto>> GetHotelPreviewsWithName(string name)
    {
        var hotelPreviews = await _hotelService.GetHotelPreviewsWithName(name);

        // Return empty list if an error has occured
        if (hotelPreviews == null)
        {
            return new List<HotelPreviewDto>();
        }

        return hotelPreviews.Select(x => new HotelPreviewDto()
        {
            Id = x.Id,
            Name = x.Name,
            AddressLine1 = x.AddressLine1,
            City = x.City,
            PostalCode = x.PostalCode,
            LowestPrice = x.LowestPrice
        }).ToList();
    }
}
