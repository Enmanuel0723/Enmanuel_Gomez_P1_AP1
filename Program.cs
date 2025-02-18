using Enmanuel_Gomez_P1_AP1.Components;

using Components;
using DAL;
using Services;
using Microsoft.EntityFrameworkCore;
using Enmanuel_Gomez_P1_AP1.DAL.Ap1_P1.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(connectionString));
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<AportesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
