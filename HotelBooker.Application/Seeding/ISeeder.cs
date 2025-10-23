namespace HotelBooker.Application.Seeding;
public interface ISeeder
{
    Task<bool> SeedData();

    Task<bool> ResetData();
}
