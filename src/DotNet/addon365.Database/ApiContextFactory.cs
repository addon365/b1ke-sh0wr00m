using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace addon365.Database
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContextFactory()
        {
        }


        public ApiContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=config69;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApiContext(builder.Options);
        }
    }
}