// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RobotWars.Application.Logger;
using RobotWars.Application.Creators;
using RobotWars.Application.Entity;
using RobotWars.Application.CommandProcess;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole()
        ).BuildServiceProvider();




var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddTransient<IConsoleLogger, CommandLineLogger>();
    services.AddTransient<IRobotProcess, RobotProcess>();
    services.AddTransient<IArenaProcess, ArenaProcess>();
    services.AddTransient<IRobotBuilder, RobotBuilder>();
    services.AddTransient<IArenaBuilder, ArenaBuilder>();
    services.AddTransient<IRobot, Robot>();
    services.AddTransient<IArena, Arena>();

}).Build();


var IArena = host.Services.GetService<IArena>();
var IArenaProcessor = host.Services.GetService<IArenaProcess>();
var IARenaBuilder = host.Services.GetService<IArenaBuilder>();



Console.WriteLine("Type Arena size (ex: 5 5)");

string arenaCreateCommand = Console.ReadLine();
IArena _IArena = IArenaProcessor.ProcessCommand(arenaCreateCommand);


string robotCreateCommand = string.Empty;
string robotMovementCommand = string.Empty;
///Get Inpt for Robot1

if (_IArena != null)
{
    var IRobotProcess1 = host.Services.GetService<IRobotProcess>();
    if (IRobotProcess1 != null)
    {
        Console.WriteLine("Type Robot 1 location (ex: 1 2 N)");
        robotCreateCommand = Console.ReadLine();
        IRobotProcess1.CreateCommand(robotCreateCommand, _IArena);
        Console.WriteLine("Type Robot 1 movements (ex: LMLRM)");
        robotMovementCommand = Console.ReadLine();
        IRobotProcess1.ProcessCommand(robotMovementCommand);
        IRobotProcess1.DisplayRobotStatus();
    }

    var IRobotProcess2 = host.Services.GetService<IRobotProcess>();
    if (IRobotProcess2 != null)
    {
        Console.WriteLine("Type Robot 2 location (ex: 1 2 N)");
        robotCreateCommand = Console.ReadLine();
        IRobotProcess2.CreateCommand(robotCreateCommand, _IArena);
        Console.WriteLine("Type Robot 2 movements (ex: LMLRM)");
        robotMovementCommand = Console.ReadLine();
        IRobotProcess2.ProcessCommand(robotMovementCommand);
        IRobotProcess2.DisplayRobotStatus();
    }

}

Console.ReadKey();







