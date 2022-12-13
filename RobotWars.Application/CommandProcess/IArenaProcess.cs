using RobotWars.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.CommandProcess
{
    public interface IArenaProcess 
    {
        public IArena ProcessCommand(string command);
    }
}
