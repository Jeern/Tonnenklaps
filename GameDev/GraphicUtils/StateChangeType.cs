using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDev.GraphicUtils
{
    public enum StateChangeType
    {
        None = 0,
        Forwarding = 1,
        Alternating = 2,
        Repeating = 3,
        Random = 4
    }
}
