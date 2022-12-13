using RobotWars.Application.Creators;
using RobotWars.Application.Entity;
using System.Text.RegularExpressions;


namespace RobotWars.Application.CommandProcess
{
    public class ArenaProcess : IArenaProcess
    {

        private const string widthValue = "width";
        private const string heightValue = "height";
        Regex regexPattern = new Regex(String.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", widthValue, heightValue));
        private readonly IArenaBuilder _IArenaBuilder;

        public ArenaProcess(IArenaBuilder IArenaBuilder)
        {
            _IArenaBuilder = IArenaBuilder;
        }
        public IArena ProcessCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new ArgumentException("Arena create command can not be empty.");

            Match match = regexPattern.Match(command);
            if (!match.Success)
                throw new ArgumentException("The arena dimensions should be '<maxWidth> <maxHeight>' (ex. '10 10')");

            int width = Convert.ToInt32(match.Groups[widthValue].Value);
            int height = Convert.ToInt32(match.Groups[heightValue].Value);

            if (!_IArenaBuilder.ValidateArena(width, height))
                throw new ArgumentException("The arena dimensions is not valid.");

            return _IArenaBuilder.CreateArena(width, height);


        }
    }
}
