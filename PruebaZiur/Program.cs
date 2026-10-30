using PruebaZiur.Components;
using PruebaZiur.Service;

var builder = WebApplication.CreateBuilder(args);
var baseUrl = builder.Configuration["ZiurApi:BaseUrl"];

if (string.IsNullOrWhiteSpace(baseUrl))
{
    throw new InvalidOperationException(
        "Erro en ZiurApi-BaseUrl en appsettings.json.");
}

builder.Services.AddHttpClient<Serviciocs>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
