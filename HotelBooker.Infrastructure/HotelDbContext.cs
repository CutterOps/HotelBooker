using HotelBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Infrastructure;
public class HotelDbContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<RoomType> RoomTypes { get; set; }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>(
            room =>
            {
                room.HasOne(r => r.RoomType)
                    .WithMany(r => r.Rooms)
                    .HasForeignKey(r => r.RoomTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                room.HasOne(r => r.Hotel)
                    .WithMany(h => h.Rooms)
                    .HasForeignKey(r => r.HotelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
    }
}