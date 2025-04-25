using EntityFrameworkCoreEncryptColumnExample.Models;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace EntityFrameworkCoreEncryptColumnExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ICryptographyService, ReverseCryptographyService>();
            builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();

            var databaseFactory = new DatabaseFactory();
            var connectionString = databaseFactory.GetConnectionStringByDatabase(DatabaseType.MSSqlServer);
            builder.Services.AddDbContext<ExampleDbContext>(options => options.UseNpgsql(connectionString));
            //builder.Services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
