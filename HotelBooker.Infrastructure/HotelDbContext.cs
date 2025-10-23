using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Infrastructure;
public class HotelDbContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
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
                Name = "The Harbour View Residence",
                AddressLine1 = "142 George Street",
                AddressLine2 = "The Rocks",
                City = "Sydney",
                Region = "NSW",
                PostalCode = "2000",
                Country = "Australia",
                BookingRef = "E8802"
            }
        );

    }
}