
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDemo.Control
{
    public static class GameStateManager
    {
        internal static Dictionary<string, Flag> flags = new Dictionary<string, Flag>();

        //public static void 

        public static Flag GetFlag(string flagName)
        {
            if (!flags.ContainsKey(flagName))
            {
                return null;
            }
            return flags[flagName];
        }
    }
}
