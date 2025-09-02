using EmployeeAppV3.Web.Services;

namespace EmployeeAppV3.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<EmployeeService>(); // Allt blir olika
            //builder.Services.AddScoped<EmployeeService>(); // Låter alla service vara det samma
            //builder.Services.AddSingleton<EmployeeService>(); // Låter det vara samma tills läsaren är avstängd

            //builder.Services.AddTransient<IUtilitiesService, EmployeeService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
