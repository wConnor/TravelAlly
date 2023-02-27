using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelAlly.Data;
using Microsoft.Extensions.DependencyInjection;
using TravelAlly.Repositories;
using TravelAlly.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TravelAllyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TravelAllyContext") ?? throw new InvalidOperationException("Connection string 'TravelAllyContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<StationRepository>();
builder.Services.AddScoped<StationService>();
builder.Services.AddScoped<TransportRepository>();
builder.Services.AddScoped<TransportService>();
builder.Services.AddScoped<RoutePlannerService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

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
