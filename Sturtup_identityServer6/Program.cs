using Duende.IdentityServer.Test;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sturtup_identityServer6;
using Sturtup_identityServer6.DbContextIdentity;
using Sturtup_identityServer6.Model;
using Sturtup_identityServer6.Model.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(ConfigIdentity.ApiScopes)
    .AddInMemoryClients(ConfigIdentity.clients)
    .AddTestUsers(TestUsers.Users)
    .AddDeveloperSigningCredential();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddDbContext<DbContextApp>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DbContextApp>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IDIntilializer, Intilializer>();


app.UseIdentityServer();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();