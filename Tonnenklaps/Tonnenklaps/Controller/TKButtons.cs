using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tonnenklaps.Controller
{
    [Flags]
    public enum TKButtons
    {
        None = 0,
        Yellow = 1,
        Blue = 2,
        Red = 4,
        Green = 8
    }
}
