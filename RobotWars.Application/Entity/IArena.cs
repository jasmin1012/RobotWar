using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Application.Entity
{
    public interface IArena
    {
        public int width { get; set; }
        public int height { get; set; }
    }
}
