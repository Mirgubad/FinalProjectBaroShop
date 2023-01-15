using Core.Entities;
using Core.Utilities.FileService;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstarct;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Services.Abstract;
using Web.Services.Concrete;
using AdminAbstractService = Web.Areas.Admin.Services.Abstract;
using AdminConcreteService = Web.Areas.Admin.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IUrlHelper>(factory =>
{
    var actionContext = factory.GetService<IActionContextAccessor>()
                               .ActionContext;
    return new UrlHelper(actionContext);
});


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("DataAccess")));

builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();



builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireUppercase = false;

    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;

    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.AllowedForNewUsers = true;
});


#region Repository
builder.Services.AddScoped<IHomeMainSliderRepository, HomeMainSliderRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISpecialSliderRepository, SpecialSliderRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();



#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<AdminAbstractService.IAccountService, AdminConcreteService.AccountService>();
builder.Services.AddScoped<AdminAbstractService.IEmailService, AdminConcreteService.EmailService>();
builder.Services.AddScoped<AdminAbstractService.IHomeMainSliderService, AdminConcreteService.HomeMainSliderService>();
builder.Services.AddScoped<AdminAbstractService.IBrandService, AdminConcreteService.BrandService>();
builder.Services.AddScoped<AdminAbstractService.ISpecialSliderService, AdminConcreteService.SpecialSliderService>();
builder.Services.AddScoped<AdminAbstractService.IColorService, AdminConcreteService.ColorService>();
builder.Services.AddScoped<AdminAbstractService.IProductService, AdminConcreteService.ProductService>();
builder.Services.AddScoped<AdminAbstractService.ISizeService, AdminConcreteService.SizeService>();





#endregion



var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var _configuration = scope.ServiceProvider.GetService<IConfiguration>();
    // Generate the token

    // Send the email


    await DbInitialize.SeedAsync(userManager, roleManager, _configuration);
}



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
        name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();