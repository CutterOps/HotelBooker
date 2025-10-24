using HotelBooker.Application.Bookings;
using HotelBooker.Application.Hotels;
using HotelBooker.Application.Rooms;
using HotelBooker.Application.RoomTypes;
using HotelBooker.Application.Seeding;
using HotelBooker.Infrastructure;
using HotelBooker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

namespace HotelBooker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<HotelDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName));
            });

            builder.Services.AddSerilog();

            //#if DEBUG
            builder.Services.AddScoped<ISeeder, Seeder>();

            //#endif
            // NOTE: Optionally I could put all the services/interfaces into separate folders and use Reflection to automatically register them for Dependency Injection
            // Logger

            //
            // Repositories
            // 
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            //
            // Services
            //
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
