using HotelBooker.Application.Hotels.Dtos;
using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Hotels;
public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    /// <summary>
    /// Depending how many hotels there are. Pagination would be a good idea here.
    /// </summary>
    public async Task<List<HotelPreviewDto>> GetHotelPreviewsWithName(string name)
    {
        IEnumerable<Hotel> hotels;

        if (string.IsNullOrWhiteSpace(name))
        {
            hotels = await _hotelRepository.GetAll(); 
        }
        else
        {
            hotels = await _hotelRepository.GetAllLikeName(name);
        }
         

        // Return empty list if an error has occured
        if (hotels == null)
        {
            return new List<HotelPreviewDto>();
        }

        return hotels.Select(x => new HotelPreviewDto()
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
