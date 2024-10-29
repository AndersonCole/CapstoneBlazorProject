using CapstoneNuzlockeSoulLinkTracker.Components;
using NuzlockeSoulLinkClassLibrary.Data;
using NuzlockeSoulLinkClassLibrary.DataAccess;

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add all services here
builder.Services.AddTransient<ISqlAccess, SqlAccess>();
builder.Services.AddScoped<PlayerAccount>();
builder.Services.AddScoped<NavMenuData>();
builder.Services.AddScoped<PokemonData>();
builder.Services.AddScoped<PlayerData>();
builder.Services.AddScoped<ActiveRunsData>();
builder.Services.AddScoped<CreateRunsData>();
builder.Services.AddScoped<JoinRunsData>();
builder.Services.AddScoped<OngoingRunsData>();
builder.Services.AddScoped<LeaderboardData>();

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
