using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PCShop.Data;

namespace PCShop.Inbfrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<PCShopDbContext>();

            data.Database.Migrate();

            var initialDataSeeder = new InitialDataSeeder(data);
            initialDataSeeder.StartSeeding();

            return app;
        }
    }
}
