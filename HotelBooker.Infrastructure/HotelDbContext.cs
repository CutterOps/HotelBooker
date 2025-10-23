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
}
