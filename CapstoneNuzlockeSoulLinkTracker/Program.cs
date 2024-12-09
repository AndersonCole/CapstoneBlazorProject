using CapstoneNuzlockeSoulLinkTracker.Components;
using Microsoft.AspNetCore.CookiePolicy;
using NuzlockeSoulLinkClassLibrary.Data;
using NuzlockeSoulLinkClassLibrary.DataAccess;

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add all services here
builder.Services.AddTransient<ISqlAccess, SqlAccess>();
builder.Services.AddScoped<AdminData>();
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

app.UseStaticFiles(new StaticFileOptions
{ OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("X-Content-Type-Options", "nosniff") });

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Type-Options", "SAMEORIGIN");
    context.Response.Headers.Append("X-Xss-Protection", "1");
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
    context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'; frame-ancestors 'none'; form-action 'self'");
    context.Response.Headers.Remove("Server");
    context.Response.Headers.Remove("X-Powered-By");
    await next();
});

app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict,
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
