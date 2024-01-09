using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppWeb.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Reservations");
    options.Conventions.AuthorizeFolder("/Dishes");
    options.Conventions.AllowAnonymousToPage("/Dishes/Index");
    options.Conventions.AllowAnonymousToPage("/Dishes/Details");
    options.Conventions.AuthorizeFolder("/Clients", "AdminPolicy");


});
builder.Services.AddDbContext<AppWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppWebContext") ?? throw new InvalidOperationException("Connection string 'AppWebContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("AppWebContext") ?? throw new InvalidOperationException("Connectionstring 'AppWebContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
