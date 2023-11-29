using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentException("Connection string is not found");
builder.Services.AddDbContextPool<MyDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dean}/{action=Create}/{id?}");

app.Run();
