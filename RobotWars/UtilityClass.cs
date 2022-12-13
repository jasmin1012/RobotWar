using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Console
{
    public class UtilityClass
    {
        public static IEnumerable Parse(string input)
        {
            return input.Select(c => c);
        }
    }
}
