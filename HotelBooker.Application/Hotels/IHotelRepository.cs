using HotelBooker.Domain.Entities;
namespace HotelBooker.Application.Hotels;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllLikeName(string name);
}
