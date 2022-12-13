using RobotWars.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.CommandProcess
{
    public interface IRobotProcess 
    {
        public void CreateCommand(string command, IArena arena);
        public void ProcessCommand(string command);
        public void DisplayRobotStatus();

    }
}
