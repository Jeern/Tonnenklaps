using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using GameDev.Utils;
using Microsoft.Xna.Framework;

namespace Tonnenklaps.Sound
{
    public static class Sounds
    {
        private static Random r = new Random();

        private static SoundEffectInstance m_PointP1;
        private static SoundEffectInstance PointP1
        {
            get
            {
                if (m_PointP1 == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP1");
                    m_PointP1 = effect.CreateInstance();
                }
                return m_PointP1;
            }
        }
        private static void PlayPointP1()
        {
            PointP1.Play();
        }

        private static SoundEffectInstance m_PointP2;
        private static SoundEffectInstance PointP2
        {
            get
            {
                if (m_PointP2 == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP1");
                    m_PointP2 = effect.CreateInstance();
                }
                return m_PointP2;
            }
        }
        private static void PlayPointP2()
        {
            PointP2.Play();
        }

        private static SoundEffectInstance m_PointP3;
        private static SoundEffectInstance PointP3
        {
            get
            {
                if (m_PointP3 == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP3");
                    m_PointP3 = effect.CreateInstance();
                }
                return m_PointP3;
            }
        }
        private static void PlayPointP3()
        {
            PointP3.Play();
        }

        private static SoundEffectInstance m_PointP4;
        private static SoundEffectInstance PointP4
        {
            get
            {
                if (m_PointP4 == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP4");
                    m_PointP4 = effect.CreateInstance();
                }
                return m_PointP4;
            }
        }
        private static void PlayPointP4()
        {
            PointP4.Play();
        }

        public static void PlayPoint(PlayerIndex index)
        {
            switch (index)
            {
                case PlayerIndex.One:
                    PlayPointP1();
                    break;
                case PlayerIndex.Two:
                    PlayPointP2();
                    break;
                case PlayerIndex.Three:
                    PlayPointP3();
                    break;
                case PlayerIndex.Four:
                    PlayPointP4();
                    break;
                default:
                    throw new ArgumentException("No such index");
            }
        }


    }
}
