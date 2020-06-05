using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Service
{
    public class GameType
    {
        [Flags]
        enum gametype
        {
            Action = 1,
            Adventure = 2,
            Editors = 4,
            Puzzle = 8,
            Racing = 16,
            RPG = 32,
            Shooter = 64,
            Strategy = 128,
            Survival = 256,
            ControllerSupport = 512,
            CoOp = 1024,
            SinglePlayer = 2048,
            Multiplayer = 4096,
            Windows = 8192,
            MacOS = 16384,
        }

        public List<string> getGameType(int n)
        {
            List<string> res = new List<string>();
            string[] str = Enum.GetNames(typeof(gametype));
            int i = 0;
            while (n != 0)
            {
                if ((n & (~n + 1)) == 1) res.Add(str[i]);
                i++;
                n = n >> 1;
            }
            return res;
        }

        public bool searchGameType(int SearchType, int ProductType)
        {
            return (SearchType & ProductType) == SearchType;

        }
    }
}