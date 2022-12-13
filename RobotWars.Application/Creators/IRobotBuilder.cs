using RobotWars.Application.Entity;
using RobotWars.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.Creators
{
    public interface IRobotBuilder
    {
        IRobot Create(int xPosition, int yPosition, IArena arena, Direction direction);
        public bool EnterInArena(int xPosition, int yPosition, IArena arena);
        public bool IsValidDirection(int xPosition, int yPosition);
        public void Move(IRobot robot);
        public void Rotate(IRobot robot, char rotateCommand);
    }
}
