using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Categories.AnyAsync())
        {
            var electronics = new Category
            {
                Name = "Electronics"
            };

            var books = new Category
            {
                Name = "Books"
            };

            context.Categories.AddRange(
                electronics,
                books);

            await context.SaveChangesAsync();

            context.Products.AddRange(
                new Product
                {
                    Name = "MacBook Pro",
                    Price = 1999.99m,
                    CategoryId = electronics.Id
                },
                new Product
                {
                    Name = "iPhone",
                    Price = 999.99m,
                    CategoryId = electronics.Id
                },
                new Product
                {
                    Name = "Clean Code",
                    Price = 39.99m,
                    CategoryId = books.Id
                });

            await context.SaveChangesAsync();
        }
    }
}
