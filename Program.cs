using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HRsystem.Data;
using HRsystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HRsystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRsystemContext") ?? throw new InvalidOperationException("Connection string 'HRsystemContext' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<HRsystemContext>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {

        //options.Cookie.Name = "RememberMeCookie";

        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";

        /*
         *  ExpireTimeSpan选项用于设置Cookie的过期时间。
         *  在这个例子中，Cookie的过期时间被设置为30天。
         *  这意味着，如果用户在30天内没有再次访问网站，那么Cookie将会过期，用户需要重新登录。

            SlidingExpiration选项用于指定是否启用滑动过期。
            如果启用了滑动过期，那么每当用户在过期时间的一半时访问网站时，Cookie的过期时间都会被重置为原来的值。
            例如，在这个例子中，如果用户在15天内访问了网站，那么Cookie的过期时间将被重置为30天。
         */

        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;

    });

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("SuperAdminOnly", policy =>
    policy.RequireAssertion(context =>
        context.User.HasClaim(c => c.Type == "Authority" && c.Value == "0")));

    options.AddPolicy("AdminLest", policy =>
    policy.RequireAssertion(context =>
        context.User.HasClaim(c => c.Type == "Authority" && (c.Value == "1" || c.Value == "0"))));

    options.AddPolicy("AdminOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "Authority" && c.Value == "1")));
    /*
    options.AddPolicy("SelfOrAdminOnly", policy =>
    policy.RequireAssertion(context =>
    {
        var httpContext = (context.Resource as AuthorizationFilterContext)?.HttpContext;
        var routeData = httpContext?.GetRouteData();
        var resourceId = routeData?.Values["Id"]?.ToString();
        if (resourceId == null)
        {
            return false;
        }
        return context.User.HasClaim("authority", "1") ||
               context.User.HasClaim("Id", resourceId);
    }));
     */

});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//AddCookie
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
