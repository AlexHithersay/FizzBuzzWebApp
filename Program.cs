using FizzBuzzWebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FizzBuzzWebAppDBContext>(options => options.UseSqlite(builder.Configuration["WebAPIConnection"]));
builder.Services.AddScoped<IFizzBuzzWebAppRepo, FizzBuzzWebAppRepo>();
builder.Services.AddRazorPages();


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

app.UseAuthorization();

app.MapRazorPages();


IFizzBuzzWebAppRepo repo = app.Services.CreateScope().ServiceProvider.GetRequiredService<IFizzBuzzWebAppRepo>();

// Database populated on web app start up.
repo.PopulateDBTable();


app.Run();
