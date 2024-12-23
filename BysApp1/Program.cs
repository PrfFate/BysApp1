using Microsoft.EntityFrameworkCore;
using BysApp1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // MVC i�in
builder.Services.AddControllers(); // API i�in de eklemeyi unutmay�n

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session s�resi
    options.Cookie.HttpOnly = true; // Cookie sadece HTTP �zerinden eri�ilebilir olsun
    options.Cookie.IsEssential = true; // GDPR uyumlulu�u i�in gerekli
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext ekleme
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HTTP client for API calls
builder.Services.AddHttpClient(); // Bu, API ile ileti�im kurmam�z� sa�layacak

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// Add Session Middleware
app.UseSession();
app.UseAuthorization();
// Map Controller Routes
app.MapControllers(); // API'ler i�in gerekli y�nlendirme

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
