using RobotWars.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.Entity
{
    public interface IRobot
    {
        public int Xpostion { get; set; }
        public int Yposition { get; set; }
        public Direction Direction { get; set; }
        public IArena Arena { get; set; }

    }
}
