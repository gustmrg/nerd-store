namespace NSE.WebApp.MVC.Configuration;

public static class AppConfig
{
    public static void AddAppConfiguration(this IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public static void UseAppConfiguration(this IApplicationBuilder app, 
                                                IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityConfiguration();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}