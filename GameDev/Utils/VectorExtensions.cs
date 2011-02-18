using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameDev.Utils
{
    public static class VectorExtensions
    {
        public static Vector2 PerpVector(this Vector2 vector2)
        {
            return new Vector2(vector2.Y, -vector2.X);
        }
    }
}
