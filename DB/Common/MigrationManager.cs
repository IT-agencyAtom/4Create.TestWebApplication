using Microsoft.EntityFrameworkCore;
using TestWebApplication.DB.Models;
using TestWebApplication.Models;

namespace TestWebApplication.DB.Common
{
    public static class MigrationManager
    {
        public static async Task<WebApplication> MigrateDatabase(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            await using var appContext = scope.ServiceProvider.GetRequiredService<TestAppDbContext>();
            try
            {
                await appContext.Database.MigrateAsync();
                await EnsureSeedData(appContext);
            }
            catch (Exception ex)
            {
                //Log errors or do anything you think it's needed
                throw;
            }

            return webApp;
        }

        public static async Task EnsureSeedData(TestAppDbContext dbContext)
        {
            if (!await dbContext.Users.AnyAsync())
            {
                await dbContext.Users.AddAsync(new User
                {
                    UserName = "Admin",
                    Password = "password"

                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}