using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.Logger
{
    public class CommandLineLogger : IConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("LOG: {0}", message);
        }
    }
}
