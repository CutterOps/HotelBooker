using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelBooker.Infrastructure;
public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{

    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();

        IConfigurationRoot configRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionString = configRoot.GetConnectionString("Default");

        optionsBuilder.UseSqlServer(connectionString);


        return new HotelDbContext(optionsBuilder.Options);
    }
}