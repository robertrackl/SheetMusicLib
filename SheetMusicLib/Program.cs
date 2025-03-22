using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using SheetMusicLib.Components;
using SheetMusicLib.Models;
using SheetMusicLib.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add localization services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"), // Default culture
        new CultureInfo("de-DE"), // German
        new CultureInfo("fr-FR"), // French
        new CultureInfo("es_ES"), // Spanish
        new CultureInfo("it-IT"), // Italian
    };

    options.DefaultRequestCulture = new RequestCulture("en-US"); // Set default culture
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});

// Add DbContext using Dependency Injection
builder.Services.AddDbContextFactory<RamLibContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RamLibConnection")));

builder.Services.AddScoped<ThemeService>(sp => new ThemeService(sp.GetRequiredService<DbContextOptions<RamLibContext>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
