using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Util
{
    public static class ColorUtils
    {
        public static Color GetFrontColor(PossibleColors color)
        {
            switch (color)
            {
                case PossibleColors.Blue:
                    return Color.Blue;
                case PossibleColors.Red:
                    return Color.Red;
                case PossibleColors.Yellow:
                    return Color.Yellow;
                case PossibleColors.Green:
                    return Color.Green;
                default:
                    throw new ArgumentException("Cannot convert this color");
            }
        }

        public static Color GetBackColor(PossibleColors color)
        {
            switch (color)
            {
                case PossibleColors.Blue:
                    return Color.Brown;
                case PossibleColors.Red:
                    return Color.Brown;
                case PossibleColors.Yellow:
                    return Color.Brown;
                case PossibleColors.Green:
                    return Color.Brown;
                default:
                    throw new ArgumentException("Cannot convert this color");
            }
        }

        private static Random random = new Random();

        public static PossibleColors GetRandomColor()
        {
            int r = random.Next(4);
            return (PossibleColors)Enum.GetValues(typeof(PossibleColors)).GetValue(r);
            //switch (r)
            //{
            //    case 0:
            //        return Color.B
            //}

        }


    }
}
