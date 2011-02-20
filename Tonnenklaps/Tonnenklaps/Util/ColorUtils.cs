using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tonnenklaps.Util
{
    public static class ColorUtils
    {
        public static PossibleColors ButtonToColor(Buttons button)
        {
            switch (button)
            {
                case Buttons.A:
                    return PossibleColors.Green;

                case Buttons.B:
                    return PossibleColors.Red;

                case Buttons.X:
                    return PossibleColors.Blue;

                case Buttons.Y:
                    return PossibleColors.Yellow;

                default:
                    return PossibleColors.None;
            }
        }


        public static Color GetRandomColor(PossibleColors color)
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

        public static PossibleColors GetPlayerColor(PlayerIndex index)
        {
            switch (index)
            {
                case PlayerIndex.One:
                    return PossibleColors.Blue;
                case PlayerIndex.Two:
                    return PossibleColors.Green;
                case PlayerIndex.Three:
                    return PossibleColors.Red;
                case PlayerIndex.Four:
                    return PossibleColors.Yellow;
                default:
                    throw new ArgumentException("PlayerIndex eksisterer ikke");
            }
        }


    }
}
