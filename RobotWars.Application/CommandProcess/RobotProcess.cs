using RobotWars.Application.Creators;
using RobotWars.Application.Entity;
using RobotWars.Application.Enum;
using RobotWars.Application.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotWars.Application.CommandProcess
{
    public class RobotProcess : IRobotProcess
    {
        private const string xPositionName = "XPosition";
        private const string yPositionName = "YPosition";
        private const string directionName = "Direction";

        Regex regexPattern = new Regex(string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[N|E|S|W])$", xPositionName, yPositionName, directionName));

        private readonly IRobotBuilder _IRobotBuilder;
        public IRobot _IRobot;
        private readonly IConsoleLogger _ILogger;


        public RobotProcess(IRobotBuilder IRobotBuilder, IRobot IRobot, IConsoleLogger ILogger)
        {
            _IRobot = IRobot;
            _ILogger = ILogger;
            _IRobotBuilder = IRobotBuilder;
        }

        // <summary>
        /// This method is for creating Robot with command for ex : '1 2 N'. 1 is XPosiion, 2 is YPosition and N is direction.
        /// </summary>
        /// <param name="command">Robot create command.</param>
        /// <param name="arena">Arena.</param>
        /// <returns></returns>
        public void CreateCommand(string command, IArena arena)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentException("Create command can not be empty.");
            if (arena == null) throw new ArgumentException("Arena can not be null or empty.");

            Match match = regexPattern.Match(command);
            if (!match.Success)
            {
                _ILogger.Log("The robot position should be '<X> <Y> <direction>' (ex: '1 2 N')");
                return;
            }
            int xPosition = Convert.ToInt32(match.Groups[xPositionName].Value);
            int yPosition = Convert.ToInt32(match.Groups[yPositionName].Value);
            Direction direction = ConvertToDirection(match.Groups[directionName].Value);

            try
            {
                _IRobot = _IRobotBuilder.Create(xPosition, yPosition, arena, direction);
                _ILogger.Log(String.Format("Robot creation successfull."));
            }
            catch (Exception ex)
            {
                _ILogger.Log(String.Format("Robot creation failed."));
                _ILogger.Log(String.Format("Failed Reason : {0}", ex.ToString()));
            }

        }

        public void DisplayRobotStatus()
        {
            _ILogger.Log(String.Format("Robot new Piosition is XPostion: {0}  YPosition: {1}  Direction:{2}", _IRobot.Xpostion, _IRobot.Yposition, _IRobot.Direction));
            _ILogger.Log(String.Format("Robot new position is : {0} {1} {2}", _IRobot.Xpostion, _IRobot.Yposition, _IRobot.Direction));
        }

        // <summary>
        /// This method is for moving and rotation of robot. for e.x : LMRM , L: Left Movement, R: Rigt Movement, M : One stop forward.
        /// </summary>
        /// <param name="command">Robot movement command.</param>
        /// <returns></returns>
        public void ProcessCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentException("Process command can not be empty.");

            try
            {

                var commandList = command.ToCharArray();

                foreach (var movementCommand in commandList)
                {
                    if (movementCommand == 'L' || movementCommand == 'R')
                    {
                        _IRobotBuilder.Rotate(_IRobot, movementCommand);
                    }
                    else if (movementCommand == 'M')
                    {
                        _IRobotBuilder.Move(_IRobot);
                    }
                }
            }
            catch (Exception ex)
            {
                _ILogger.Log(String.Format("Error {0}", ex.ToString()));
            }
        }

        // <summary>
        /// This method if for converting direction value to enum value.
        /// </summary>
        /// <param name="direction">Direction (N,W,S,E).</param>
        /// <returns></returns>
        private Direction ConvertToDirection(string direction)
        {
            if (string.IsNullOrEmpty(direction)) throw new ArgumentException("Direction can not be empty.");

            switch (direction.ToLowerInvariant())
            {
                case "e":
                    return Direction.E;
                case "s":
                    return Direction.S;
                case "w":
                    return Direction.W;
                default:
                    return Direction.N;
            }
        }

    }
}
