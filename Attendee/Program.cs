using Attendee.Context;
using Attendee.Repository.Implementation;
using Attendee.Repository.Interface;
using Attendee.Services.Implementation;
using Attendee.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Attendee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AttendeeConnection");


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
            builder.Services.AddScoped<IAttendeeService, AttendeeService>();
            

            builder.Services.AddDbContext<AttendeeContext>(
    options => options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)

    )
);


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
