using Duende.IdentityServer.Test;
using Sturtup_identityServer6;
using UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
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

app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();

app.Run();
