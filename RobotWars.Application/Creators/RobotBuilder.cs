using RobotWars.Application.Entity;
using RobotWars.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.Creators
{
    public class RobotBuilder : IRobotBuilder
    {
        private const int RobotMinPosition = 0;
        private const int RobotMaxPosition = 270;
        private const int RobotRotation = 90;
        private const char RightMove = 'R';
        private const char LeftMove = 'L';

        private readonly IRobot _IRobot;
        public RobotBuilder(IRobot IRobot)
        {
            _IRobot = IRobot;
        }

        /// <summary>
        /// This method is for creating Robot.
        /// </summary>
        /// <param name="xPosition">Robot intial xPosition in Arena. </param>
        /// <param name="yPosition">Robot intial yPosition in Arena. </param>
        /// <param name="arena">Arena with property(width,height).</param>
        /// <param name="direction">Robot direction with enum(N,W,S,E).</param>
        /// <returns>IRobot</returns>
        public IRobot Create(int xPosition, int yPosition, IArena arena, Direction direction)
        {
            if (!IsValidDirection(xPosition, yPosition)) throw new ArgumentException("The robot direction should be positive.");
            if (!EnterInArena(xPosition, yPosition, arena)) throw new ArgumentException("Can not be placed in arena.");

            _IRobot.Xpostion = xPosition;
            _IRobot.Yposition = yPosition;
            _IRobot.Direction = direction;
            _IRobot.Arena = arena;
            return _IRobot;
        }

        /// <summary>
        /// This method is for checking robot can be placed in arena or not. Will return true if robot can be placed in arena otherwise will retrun false.
        /// </summary>
        /// <param name="xPosition">Robot xPosition. </param>
        /// <param name="yPosition">Robot yPosition. </param>
        /// <param name="arena">Arena with property(width,height).</param>
        /// <returns>bool</returns>
        public bool EnterInArena(int xPosition, int yPosition, IArena arena)
        {
            if (arena == null)
                throw new NullReferenceException("Arena can not be null.");

            return xPosition <= arena.width && yPosition <= arena.height;
        }

        // <summary>
        /// This method is for validation position while creating robot.
        /// </summary>
        /// <param name="xPosition">Robot xPosition. </param>
        /// <param name="yPosition">Robot yPosition. </param>
        /// <returns>bool</returns>
        public bool IsValidDirection(int xPosition, int yPosition)
        {
            if (xPosition < 0 || yPosition < 0)
                return false;

            return xPosition >= 0 && yPosition >= 0;
        }

        // <summary>
        /// This method is for robot movement by one step with new position(X,Y).
        /// </summary>
        /// <param name="robot">Robot object with all property.</param>
        /// <returns></returns>
        public void Move(IRobot robot)
        {
            if (robot == null) throw new NullReferenceException("Robot can not be null.");
            switch (robot.Direction)
            {
                case Direction.N:
                    if (robot.Yposition + 1 <= robot.Arena.height)
                        robot.Yposition++;
                    break;
                case Direction.E:
                    if (robot.Xpostion + 1 <= robot.Arena.width)
                        robot.Xpostion++;
                    break;
                case Direction.W:
                    if (robot.Xpostion > 0)
                        robot.Xpostion--;
                    break;
                case Direction.S:
                    if (robot.Yposition > 0)
                        robot.Yposition--;
                    break;
            }
        }

        // <summary>
        /// This method is for rotating robot in new direction(N,W,S,E) based on condition, If robotcommand is 'L' then will rotate in left direction, if 'R' then will rotate in right direction.
        /// </summary>
        /// <param name="robot">Robot object with all property.</param>
        /// <param name="rotateCommand">Rotate command(L,R)</param>
        /// <returns></returns>
        public void Rotate(IRobot robot, char rotateCommand)
        {
            if (robot == null) throw new NullReferenceException("Robot can not be null.");
            int robotCurrentDirection = (int)robot.Direction;
            switch (rotateCommand)
            {
                case RightMove:
                    robotCurrentDirection = robot.Direction == Direction.W ? RobotMinPosition : robotCurrentDirection + RobotRotation;
                    break;
                case LeftMove:
                    robotCurrentDirection = robot.Direction == Direction.N ? RobotMaxPosition : robotCurrentDirection - RobotRotation;
                    break;
                default:
                    throw new ArgumentException("Argument is not valid.");
            }
            robot.Direction = (Direction)robotCurrentDirection;
        }
    }
}
