using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.GraphicUtils;
using GameDev.Sprites;
using GameDev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tonnenklaps.Sprites
{
   public class Club :Sprite
   {
       private ImageState m_waitingState, m_hittingState, m_missedState;


       
       public Club(Vector2 position, Color color)
       {
           this.Position = position;
           this.TheColor = color;
           this.Scale = 1.1F;
           Initialize();
       }

       protected override void LoadContent()
       {
           base.LoadContent();
           int noOfHittingImages = 13;
           GameImage[] hittingImages = new GameImage[noOfHittingImages];
           for (int i = 0; i < noOfHittingImages; i++)
           {
               hittingImages[i] = 
                GameDevGame.Current.Content.Load<Texture2D>(string.Format(@"Club\club{0:0000}", i));
           }

           m_hittingState = new ImageState(hittingImages, StateChangeType.Forwarding);

           m_waitingState = new ImageState(GameDevGame.Current.Content.Load<Texture2D>(@"Club\club0000"), StateChangeType.None);
           m_waitingState.SetDefaultDelay(20);
           this.ImageState = m_waitingState;

       }


       protected override GameDev.GraphicUtils.ImageState ResetImageState()
       {
           return m_waitingState;
       }


       public void Slå()
       {

           this.ImageState = m_hittingState;
           m_hittingState.Reset();
       }

       private readonly Vector2 m_OffSet = new Vector2(0, 115);

       public override void Draw(GameTime gameTime, Color color)
       {
           if (Visible)
           {
               GameDevGame.Current.SpriteBatch.Draw(ImageState,
                  Position - (m_Camera().Position * Layer + m_OffSet),
                  null,
                  color,
                  0F,
                  Vector2.Zero, //Formerly Middle
                  Scale,
                  SpriteEffects.None,
                  Math.Min(Layer, 1f)); //Layer
           }
       }

   }
}
