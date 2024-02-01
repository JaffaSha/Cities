using Cities.Data.Repositories;
using Cities.Services;
using Microsoft.EntityFrameworkCore;
using Cities.Data.DataBaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Add DataContext.
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

//// Add services class for dependency injection of the controllers:
builder.Services.AddScoped<IRepository,CitiesRepository>();
builder.Services.AddScoped<ICitiesService,CitiesService>();

builder.Services.AddEndpointsApiExplorer(); 

//cors:
builder.Services.AddCors(options => options.AddPolicy(name: "citiesService",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
    ));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCors(policyName: "citiesService");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
