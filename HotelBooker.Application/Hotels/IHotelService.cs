using HotelBooker.Application.Hotels.Dtos;

namespace HotelBooker.Application.Hotels;
public interface IHotelService
{
    public Task<List<HotelPreviewDto>> GetHotelPreviewsWithName(string name);
}
