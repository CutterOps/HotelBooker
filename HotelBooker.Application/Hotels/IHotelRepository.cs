using HotelBooker.Domain.Entities;
namespace HotelBooker.Application.Hotels;

public interface IHotelRepository
{
    Task<string> GetHotelRef(Guid hotelId);
    Task<IEnumerable<Hotel>> GetAllLikeName(string name);

    Task<IEnumerable<Hotel>> GetAll();
}
