using RobotWars.Application.Entity;


namespace RobotWars.Application.Creators
{
    public interface IArenaBuilder
    {
        public IArena CreateArena(int width, int hegiht);
        public bool ValidateArena(int width, int hegiht);
    }
}
