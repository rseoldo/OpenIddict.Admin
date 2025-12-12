using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Seoldor.OpenIddict.Admin.UI.Components.Layout;
using Seoldor.OpenIddict.Admin.UI.Components.Pages;
using Seoldor.OpenIddict.Admin.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Serviços
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication("Cookies") // Exemplo de auth cookie
    .AddCookie("Cookies");
builder.Services.AddAuthorization();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

// Qualquer outro serviço do seu app
//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) });


var app = builder.Build();

// 🔹 Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 Autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Middleware antiforgery obrigatório para Blazor Server
app.Use(async (context, next) =>
{
    var antiforgery = context.RequestServices.GetRequiredService<IAntiforgery>();
    var tokens = antiforgery.GetAndStoreTokens(context);
    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
        new CookieOptions { HttpOnly = false });
    await next();
});

// 🔹 Endpoints
app.MapBlazorHub();
app.MapFallbackToPage("/_Host"); // ponto de entrada do Blazor Server

app.Run();
