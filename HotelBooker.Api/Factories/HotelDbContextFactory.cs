using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelBooker.Infrastructure;
public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{

    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        IConfigurationRoot configRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();
        string connectionString = configRoot.GetConnectionString("Default");

        optionsBuilder.UseSqlServer(connectionString,
            b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName));


        return new HotelDbContext(optionsBuilder.Options);
    }
}