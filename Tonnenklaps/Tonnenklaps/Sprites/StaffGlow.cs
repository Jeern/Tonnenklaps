using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.GraphicUtils;
using GameDev.Sprites;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sprites
{
   public class StaffGlow : Sprite
   {
       private ImageState glowImages;

       public StaffGlow(Vector2 position, ImageState images) : base(position, images)
       {
           Initialize();
           glowImages = images;
           this.ImageState = glowImages;
       }

       protected override GameDev.GraphicUtils.ImageState ResetImageState()
       {
           return ImageState;
       }
    }
}
