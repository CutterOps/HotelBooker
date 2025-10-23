using HotelBooker.Application.Hotels.Dtos;

namespace HotelBooker.Application.Interfaces;
public interface IHotelService
{
    public Task<List<HotelPreviewDto>> GetHotelPreviewsWithName(string name);
}
