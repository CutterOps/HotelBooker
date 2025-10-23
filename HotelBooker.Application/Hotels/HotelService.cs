using HotelBooker.Application.Hotels.Dtos;

namespace HotelBooker.Application.Hotels;
public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    public async Task<List<HotelPreviewDto>> GetHotelPreviewsWithName(string name)
    {
        var hotelPreviews = await _hotelRepository.GetAllLikeName(name);

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
            Country = x.Country
        }).ToList();
    }
}
