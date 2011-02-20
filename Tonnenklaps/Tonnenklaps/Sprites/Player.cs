using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDev.Sprites;
using Microsoft.Xna.Framework;
using GameDev.GraphicUtils;
using Microsoft.Xna.Framework.Input;

namespace Tonnenklaps.Sprites
{
    public class Player : Sprite
    {

        private DateTime stopBuzzingTime = DateTime.MinValue;

        public Player(Vector2 startPos)
            : base(startPos)
        {

        }

        protected override ImageState ResetImageState()
        {
            return null;
        }

        public PlayerIndex PlayerIndex
        {
            get;
            set;
        }

        public Crown Crown
        {
            get;
            set;
        }

        public Club Club 
        { 
            get; set; 
        }

        private int m_Point;



        public override void Reset(Vector2 startPos)
        {
            base.Reset(startPos);
            StopBuzzer();
            Points = 0;
        }

        public int Points
        {
            get
            {
                return m_Point;
            }
            set { m_Point = Math.Max(0, value); }
        }

        public void HitFeedback()
        {
            stopBuzzingTime = DateTime.Now.AddMilliseconds(100);
            GamePad.SetVibration(PlayerIndex, 1, 1);
        }


        public override void Update(GameTime gameTime)
        {
            if (DateTime.Now > stopBuzzingTime)
            {
                stopBuzzingTime = DateTime.MinValue;
                StopBuzzer();
            }
        }

        private void StopBuzzer()
        {
            GamePad.SetVibration(PlayerIndex, 0, 0);
        }

        public override void Draw(GameTime gameTime)
        {
            //base.Draw(gameTime);
        }

      
    }
}
