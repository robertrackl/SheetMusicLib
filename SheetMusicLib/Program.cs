using Microsoft.EntityFrameworkCore;
using SheetMusicLib.Components;
using SheetMusicLib.Models;  // Assuming your models are in this namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DbContext using Dependency Injection
builder.Services.AddDbContext<RamLibContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RamLibCx")));

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
