using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameDev.Sequencers;
using System.Diagnostics;

namespace GameDev.GraphicUtils
{
    public class ImageState : List<GameImage>
    {
        public ImageState(GameImage image, StateChangeType changeType) : this(new List<GameImage>() { image }, changeType)
        {
        }

        public ImageState(IEnumerable<GameImage> image, StateChangeType changeType)
        {
            AddRange(image);
            SetImageChanger(changeType);
            Reset();
        }

        public GameImage Current
        {
            get { return this[CurrentImageIndex]; }
        }

        public void SetImageChanger(StateChangeType changeType)
        {
            switch (changeType)
            {
                case StateChangeType.None:
                    ImageChanger = new StaticSequencer();
                    break;
                case StateChangeType.Alternating:
                    ImageChanger = new AlternatingSequencer(Count-1);
                    break;
                case StateChangeType.Forwarding:
                    ImageChanger = new ForwardingSequencer(Count-1);
                    break;
                case StateChangeType.Random:
                    ImageChanger = new RandomSequencer(Count-1);
                    break;
                case StateChangeType.Repeating:
                    ImageChanger = new RepeatingSequencer(Count-1);
                    break;
                default:
                    ImageChanger = new StaticSequencer();
                    break;
            }
        }

        public Sequencer ImageChanger
        {
            get;
            private set;
        }

        public static implicit operator Texture2D(ImageState state)
        {
            return state.CurrentTexture;
        }

        public static implicit operator ImageState( Texture2D state)
        {
            return new ImageState(state, StateChangeType.None);
        }

        private TimeSpan m_LastChanged = TimeSpan.MinValue;

        public void Update(GameTime time)
        {
            TimeSpan newTime = time.TotalGameTime;
            if (m_LastChanged == TimeSpan.MinValue || m_LastChanged.Add(new TimeSpan(0, 0, 0, 0, Current.Delay)) <= newTime)
            {
                m_LastChanged = newTime;
                ImageChanger.MoveNext();
            }
        }

        public Texture2D CurrentTexture
        {
            get { return Current.Texture; }
        }

        public int CurrentImageIndex
        {
            get {
                return ImageChanger.Current; }
        }

        public void Reset()
        {
            ImageChanger.Reset();
        }


    }
}
