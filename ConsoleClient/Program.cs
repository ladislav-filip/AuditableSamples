// See https://aka.ms/new-console-template for more information

using ConsoleClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Logger.Information("Start ConsoleClient...");

var services = new ServiceCollection();
services.AddSingleton<Start>();
services.AddSingleton<IConfiguration>(configuration);
services.AddLogging(conf =>
{
    conf.AddSerilog();
});
services.AddTransient<IAuditableContext, CustomAuditableContext>();
services.AddDbContext<CustomAuditableContext>(
    opt => opt.UseMySql(
        connectionString: configuration.GetConnectionString("ZetAuditable"),
        serverVersion: ServerVersion.Create(new Version(8, 0, 21), ServerType.MySql)
        )
    );


var serviceProvider = services.BuildServiceProvider();

if (args.Contains("run"))
{
    serviceProvider.GetRequiredService<Start>().Run();
}
