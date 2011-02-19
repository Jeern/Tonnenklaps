using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.GraphicUtils;
using GameDev.Sprites;
using GameDev.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace Tonnenklaps.Sprites
{
   public class Club :Sprite
   {
       private ImageState m_waitingState, m_hittingState, m_missedState;


       public Club()
       {
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
           this.ImageState = m_waitingState;

       }


       protected override GameDev.GraphicUtils.ImageState ResetImageState()
       {
           return m_waitingState;
       }


       public void Slå()
       {

           ResetImageState();
           m_hittingState.Reset();
       }

   }
}
