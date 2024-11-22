using BusinessLayer.DependencyResolver;
using CoreLayer.DependencyResolver;
using DataAccessLayer.DependencyResolver;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register services from other layers
builder.Services.IocCoreInstall();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddBusinessLayerServices();

// Add Authentication and Cookie-based services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/"; // Redirect to login page on unauthorized access
        options.LogoutPath = "/"; // Redirect to this path on logout
        options.AccessDeniedPath = "/";
        options.Cookie.Name = "MagicwallAuthCookie";
    });

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

// Add Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
