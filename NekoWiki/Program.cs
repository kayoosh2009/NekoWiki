using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// set the data-directory to the App_Data folder
var dataDirectory = Path.Combine(builder.Environment.ContentRootPath, "App_Data");
AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);

// Add services to the container
builder.Services.AddRazorPages();

// Add session service
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(60);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

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

// Add session service
app.UseSession();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    using (var db = new NekoWiki.Models.AppDbContext())
    {
        // Сама создаст файл nekowiki.db, если его еще нет
        db.Database.EnsureCreated();

        // Создаем админа при самом первом старте
        if (!db.Users.Any())
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
            db.Users.Add(new NekoWiki.Models.User
            {
                Username = "admin",
                Email = "admin@nekowiki.com",
                PasswordHash = hasher.HashPassword("admin", "admin123"),
                BornDate = DateTime.Now,
                FavCats = "All",
                LovesCats = "Yes",
                IsAdmin = true
            });
            db.SaveChanges();
        }
    }
}

app.Run();