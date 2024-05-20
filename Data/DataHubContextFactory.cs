using DataHUBWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataHUBWebApplication;

public class DataHubContextFactory : IDesignTimeDbContextFactory<DataHubContext>
{
    public DataHubContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataHubContext>();
        var connectionString = configuration.GetConnectionString("DHConnectionStrings");

        optionsBuilder.UseMySQL(connectionString);

        return new DataHubContext(optionsBuilder.Options);
    }
}
