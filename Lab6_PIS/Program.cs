using Lab6_PIS.Models;
using Newtonsoft.Json;

namespace Lab6_PIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapGet("is-11fiot-21-106", () =>
            {
                return JsonConvert.SerializeObject(
                    new MoodleData {
                        Course = 2,
                        Group = "ІС-11",
                        Surname = "Воробйов",
                        Name = "Олексiй"
                });
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}