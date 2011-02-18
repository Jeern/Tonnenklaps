using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GameDev.Sprites;

namespace GameDev.GraphicUtils
{
    public static class SpriteFactory
    {
        //Example

        ///// <summary>
        ///// Creates a new Rabbit or uses an old one if one exists
        ///// </summary>
        ///// <param name="game"></param>
        ///// <param name="startPos"></param>
        ///// <param name="sex"></param>
        ///// <param name="kid"></param>
        ///// <returns></returns>
        //public static Rabbit CreateRabbit(Game game, Vector2 startPos, Sex sex, bool kid)
        //{
        //    var spritesNotInUse = GetStack(typeof(Rabbit));
        //    Rabbit rabbit = null;
        //    if (m_SpritesNotInUse.ContainsKey(typeof(Rabbit)) && spritesNotInUse.Count > 0)
        //    {

        //        rabbit = spritesNotInUse.Pop() as Rabbit;
        //        rabbit.Reset(startPos, sex, kid);
        //    }
        //    else
        //    {
        //        rabbit = new Rabbit(game, startPos, sex, kid);
        //    }

        //    Add(rabbit);
        //    return rabbit;
        //}
        
    }
}
