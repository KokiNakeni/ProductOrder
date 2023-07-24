using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProductOrder_application.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services);
        var app = builder.Build();

        // Get the service scope to resolve the DbContext and DbInitializer
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                // Get the DbContext from the service provider
                var dbContext = services.GetRequiredService<ProductOrder_applicationContext>();

                // Seed the data using the DbInitializer
                DbInitializer.Initialize(dbContext);
            }
            catch (Exception ex)
            {
                // Handle any errors during data seeding
                Console.WriteLine("An error occurred while seeding the database: " + ex.Message);
            }
        }

        Configure(app);
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Connect to the database here.
        string connectionString = "Server=DESKTOP-5OC6KF6\\SQLEXPRESS;Database=ProductOrder;Integrated Security=True;";
        services.AddDbContext<ProductOrder_applicationContext>(options =>
            options.UseSqlServer(connectionString));

        // Add services to the container here.
        services.AddControllersWithViews();
    }

    private static void Configure(WebApplication app)
    {
        // Set up how the app will handle HTTP requests.

        if (!app.Environment.IsDevelopment())
        {
            // Show a nice error page for production.
            app.UseExceptionHandler("/Home/Error");
            // Enable HTTP Strict Transport Security (HSTS) for added security.
            app.UseHsts();
        }

        // Redirect HTTP requests to HTTPS for secure communication.
        app.UseHttpsRedirection();
        // Serve static files (e.g., CSS, JS) from wwwroot folder.
        app.UseStaticFiles();

        // Enable routing for incoming requests.
        app.UseRouting();

        // Handle authorization for access to specific resources.
        app.UseAuthorization();

        // Set up the default route for handling requests to controllers.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}
