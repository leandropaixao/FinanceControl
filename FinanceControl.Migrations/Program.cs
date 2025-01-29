
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddUserSecrets<FinanceControl.Web.SecretsReference>()
    .Build();

string? connectionString = config["ConnectionStringsServer:DefaultConnection"];

var serviceProvider = new ServiceCollection()
    .AddDbContext<FinanceControl.Web.Data.AppDbContext>(options =>
        options.UseNpgsql(connectionString))
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<FinanceControl.Web.Data.AppDbContext>();
context.Database.Migrate();

Console.WriteLine("Migration successfully applied");