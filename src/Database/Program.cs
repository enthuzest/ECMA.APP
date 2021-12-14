// See https://aka.ms/new-console-template for more information

using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

var config = builder.Build();

var connectionString = args.FirstOrDefault() ?? config["ConnectionString"];

var upgrader = DeployChanges.To
                 .SqlDatabase(connectionString)
                 .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                 .LogToConsole()
                 .Build();

var result = upgrader.PerformUpgrade();
if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();

#if DEBUG
    Console.ReadLine();
#endif

    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;
