using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //view çalışmalarını etkinleştirdik
builder.Services.AddDbContext<RepositoryContext>(options => //dbcontext etkinleştirdik
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});

var app = builder.Build();

app.UseStaticFiles(); //burası wwwroot klasörünü etkinleştirdi

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
