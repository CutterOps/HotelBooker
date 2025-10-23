using HotelBooker.Application.Seeding;
using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HotelBooker.Infrastructure;
public class Seeder : ISeeder
{
    private const int ROOM_COUNT = 2;
    private readonly ILogger<Seeder> _logger;
    private readonly HotelDbContext _context;



    public Seeder(ILogger<Seeder> logger,
        HotelDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Deletes the database. 
    /// This should not really exist at all unless in a development environment. 
    /// Could use Conditional Compilation to avoid this going to production.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> ResetData()
    {
        return await _context.Database.EnsureDeletedAsync();
    }

    /// <summary>
    /// Seeds Database with Fake Data
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SeedData()
    {
        _logger.LogInformation("Ensuring Database is created and applied the latest migrations.");

        await _context.Database.MigrateAsync();


        if (await _context.Hotels.AnyAsync())
        {
            return false;
        }

        var hotels = GetFakeHotels();

        foreach(var hotel in hotels)
        {
            await _context.Hotels.AddAsync(hotel);

            await _context.SaveChangesAsync();

            var defaultRoomTypes = GetDefaultRoomTypes(hotel.Id);

            await _context.RoomTypes.AddRangeAsync(defaultRoomTypes);

            await _context.SaveChangesAsync();

            int roomFloor = 1;
            foreach(var roomType in defaultRoomTypes) {
                for(int i = 0; i < ROOM_COUNT; i++)
                {
                    var room = new Room()
                    {
                        RoomNumber = $"F" + ((roomFloor * 100) + i).ToString("000"),
                        RoomTypeId = roomType.Id,
                        HotelId = hotel.Id
                    };

                    await _context.Rooms.AddAsync(room);
                }
                roomFloor++;
            }

            await _context.SaveChangesAsync();


        }



        return true;
    }


    private List<RoomType> GetDefaultRoomTypes(Guid hotelId)
    {
        return new List<RoomType>() {
            new RoomType() {
                Name = "Single",
                GuestCapacity = 1,
                HotelId = hotelId
            },
            new RoomType() {
                Name = "Double",
                GuestCapacity = 2,
                HotelId = hotelId
            },
            new RoomType() {
                Name = "Deluxe",
                GuestCapacity = 4,
                HotelId = hotelId
            }
        };
    }
    private List<Hotel> GetFakeHotels()
    {
        return new List<Hotel>() {
            new Hotel
            {
                Id = new Guid("13ab1a14-801b-419c-a388-0032ebb7adbb"),
                Name = "Pacific Shores Resort & Spa",
                AddressLine1 = "1200 Ocean View Drive",
                AddressLine2 = "Tower B, Suite 10",
                City = "Santa Monica",
                Region = "CA",
                PostalCode = "90401",
                Country = "USA",
                BookingRef = "A742"
            },
            new Hotel
            {
                Id =  new Guid("3e4eba53-7b38-4698-9740-8076d0d2957e"),
                Name = "The Royal Exchange Grand",
                AddressLine1 = "Threadneedle Street",
                AddressLine2 = "City of London",
                City = "London",
                Region = "England",
                PostalCode = "EC2R 8AH",
                Country = "UK",
                BookingRef = "B931"
            },
            new Hotel
            {
                Name = "Le Petit Jardin Hotel",
                AddressLine1 = "25 Rue de Rivoli",
                AddressLine2 = "",
                City = "Paris",
                Region = "Île-de-France",
                PostalCode = "75004",
                Country = "France",
                BookingRef = "C1550"
            },
            new Hotel
            {
                Id = new Guid("77aeb7e5-5f9f-4913-9fc2-9f310d5102b5"),
                Name = "Shinjuku Sky Tower Inn",
                AddressLine1 = "1 Chome-24-2 Nishi-Shinjuku",
                AddressLine2 = "Shinjuku City",
                City = "Tokyo",
                Region = "Tokyo",
                PostalCode = "160-0023",
                Country = "Japan",
                BookingRef = "D33"
            },
            new Hotel
            {
                Id = new Guid("976eab2e-519e-48c8-8895-157946836f3b"),
                Name = "The Harbour View Residence",
                AddressLine1 = "142 George Street",
                AddressLine2 = "The Rocks",
                City = "Sydney",
                Region = "NSW",
                PostalCode = "2000",
                Country = "Australia",
                BookingRef = "E8802"
            }
       };
    }
}
