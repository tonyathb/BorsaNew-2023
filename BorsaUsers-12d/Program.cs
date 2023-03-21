using ASPShopBag.Services;
using BorsaUsers_12d.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<BorsaDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<Customer>(options => 
                                options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BorsaDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        IMvcBuilder buildMVC = builder.Services.AddControllersWithViews();


        builder.Services.AddRazorPages();

        //PODtiskane na nullAttribute
        builder.Services.AddControllers(
            options =>
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

        //https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0

        if (builder.Environment.IsDevelopment())
        {
            buildMVC.AddRazorRuntimeCompilation(); // commenting out this line resolves the issue
        }
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();

        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.PrepareDataBase().Wait();// !!! my service

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}