using Microsoft.Extensions.Logging;
using RobotWars.Application.Entity;
using RobotWars.Application.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotWars.Application.Creators
{
    public class ArenaBuilder : IArenaBuilder
    {

        private readonly IArena _IArena;

        public ArenaBuilder(IArena IArena)
        {
            _IArena = IArena;
        }

        // <summary>
        /// This method is for creating arena with property width and height.
        /// </summary>
        /// <param name="width">Arena width.</param>
        /// <param name="hegiht">Arena hegiht</param>
        /// <returns>IArena</returns>
        public IArena CreateArena(int width, int hegiht)
        {
            if (!ValidateArena(width, hegiht))
                throw new ArgumentException("Hieght and width is not valid");
            if (width > 0 && hegiht > 0)
            {
                _IArena.height = hegiht;
                _IArena.width = width;
            }
            return _IArena;
        }

        // <summary>
        /// This method is for validation arena with property width and height.
        /// </summary>
        /// <param name="width">Arena width.</param>
        /// <param name="hegiht">Arena hegiht</param>
        /// <returns>bool</returns>
        public bool ValidateArena(int width, int hegiht)
        {
            return (width > 0 && hegiht > 0);
        }


    }
}
