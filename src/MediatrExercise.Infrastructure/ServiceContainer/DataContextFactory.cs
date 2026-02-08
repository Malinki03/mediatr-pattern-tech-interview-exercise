using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MediatrExercise.Infrastructure.ServiceContainer;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql("Host=localhost:5432;Username=admin;Password=12345;Database=interview");
        optionsBuilder.UseSnakeCaseNamingConvention();
        return new DataContext(optionsBuilder.Options);
    }
}