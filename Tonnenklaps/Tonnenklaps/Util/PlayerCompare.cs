using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tonnenklaps.Sprites;

namespace Tonnenklaps.Util
{
    public class PlayerCompare : IComparer<Player>
    {

        public int Compare(Player x, Player y)
        {
            return y.Points.CompareTo(x.Points);
        }
    }
}
