

namespace RobotWars.Application.Entity
{
    public class Arena : IArena
    {

        /// <summary>
        /// Create arena supplying upper x and y cordinates.
        /// Coordinates are zero based
        /// </summary>
        /// <param name="width">Upper x coordinate</param>
        /// <param name="height">Upper y coordinate</param>
        public int width { get; set; }
        public int height { get; set; }



    }
}
