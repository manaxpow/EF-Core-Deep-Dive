public static class SeedConfiguration
{
    public static async Task SeedDatabaseAsync(
    this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context =
            scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await DbSeeder.SeedAsync(context);
    }
}
