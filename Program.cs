using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FinanceControl;
using MudBlazor.Services;
using FinanceControl.Data.Repositories;
using FinanceControl.Models;
using FinanceControl.Services.Accounts;
using FinanceControl.Services.Entries;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRepository<Account>, AccountsRepository>();
builder.Services.AddScoped<IAccountsService<Account>, AccountsService>();

builder.Services.AddScoped<IRepository<Entry>, EntriesRepository>();
builder.Services.AddScoped<IEntriesService<Entry>, EntriesService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
