using BusinessLayer.DependencyResolver;
using CoreLayer.DependencyResolver;
using DataAccessLayer.DependencyResolver;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register services from other layers
builder.Services.IocCoreInstall();
builder.Services.AddDataAccessLayerServices(builder.Configuration);
builder.Services.AddBusinessLayerServices();

// Add Authentication and Cookie-based services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/"; // Redirect to login page on unauthorized access
        options.LogoutPath = "/"; // Redirect to this path on logout
        options.AccessDeniedPath = "/Home/Error404";
        options.Cookie.Name = "MagicwallAuthCookie";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                // If the request is unauthorized, redirect to 404
                if (context.Request.Path.StartsWithSegments("/Admin")|| context.Request.Path.StartsWithSegments("/Auth/Register"))
                {
                    context.Response.Redirect("/Home/Error404");
                }
                else
                {
                    context.Response.Redirect(context.RedirectUri);
                }
                return Task.CompletedTask;
            }
        };

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403 || context.Response.StatusCode == 404)
    {
        // Redirect unauthorized or forbidden users to the 404 page
        context.Response.Redirect("/Home/Error404");
    }
});
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
