global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GlobalFinance.Client;
using GlobalFinance.Client.Services;
using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Client.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IConfiguratorService, ConfiguratorService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

