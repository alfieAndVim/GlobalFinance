global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Authorization;
global using Blazored.LocalStorage;
global using GlobalFinance.Client;
global using GlobalFinance.Client.ServicesInterfaces;
global using GlobalFinance.Client.Providers;
global using GlobalFinance.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IConfiguratorService, ConfiguratorService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IEnquiryService, EnquiryService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();

