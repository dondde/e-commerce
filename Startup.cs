using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Travail1.Models;
using Travail1.Data;
using Microsoft.Extensions.Configuration;
using System;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configure Identity services
        services.AddDbContext<GameDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<User, IdentityRole>(options =>
        {
            // Configurez les options d'identité au besoin
        })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<GameDbContext>();

        services.AddHttpClient();
        services.AddControllersWithViews(); // Utilisez AddControllersWithViews à la place de AddMvc
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=}/{id?}");
        });
    }
}
