using FinanceControl.Web.Auth;
using FinanceControl.Web.Components;
using FinanceControl.Web.Data;
using FinanceControl.Web.Data.Repositories;
using FinanceControl.Web.Models;
using FinanceControl.Web.Services.Accounts;
using FinanceControl.Web.Services.Entries;
using FinanceControl.Web.Services.Users;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

//// For logs in db
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(connectionString)
//        .EnableSensitiveDataLogging()
//        .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<IRepository<Account>, AccountsRepository>();
builder.Services.AddScoped<IAccountsService<Account>, AccountsService>();
builder.Services.AddScoped<IRepository<Entry>, EntriesRepository>();
builder.Services.AddScoped<IEntriesService<Entry>, EntriesService>();
builder.Services.AddScoped<IEntriesOperations, EntriesService>();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService<User>, UserService>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();