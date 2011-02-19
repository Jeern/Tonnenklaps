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

        #region Point sounds

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

        #endregion

        #region MenuKlik sounds

        private static SoundEffectInstance m_MenuKlik;
        private static SoundEffectInstance MenuKlik
        {
            get
            {
                if (m_MenuKlik == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\MenuKlik");
                    m_MenuKlik = effect.CreateInstance();
                }
                return m_MenuKlik;
            }
        }
        public static void PlayMenuKlik()
        {
            MenuKlik.Play();
        }

        private static SoundEffectInstance m_MenuKlikDyb;
        private static SoundEffectInstance MenuKlikDyb
        {
            get
            {
                if (m_MenuKlikDyb == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\MenuKlikDyb");
                    m_MenuKlikDyb = effect.CreateInstance();
                }
                return m_MenuKlikDyb;
            }
        }
        public static void PlayMenuKlikDyb()
        {
            MenuKlikDyb.Play();
        }

        #endregion

        #region Tønderamt

        private static List<SoundEffectInstance> m_ToendeRamt = new List<SoundEffectInstance>();

        private static List<SoundEffectInstance> ToendeRamt
        {
            get
            {
                if (m_ToendeRamt.Count == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(string.Format(@"Audio\TondeRamt{0}", i));
                        m_ToendeRamt.Add(effect.CreateInstance());
                    }
                }
                return m_ToendeRamt;
            }
        }
        public static void PlayToendeRamt()
        {
            int value = r.Next(10);
            SoundEffectInstance toendeRamt;

            if (value <= 3)
            {
                toendeRamt = ToendeRamt[0];
            }
            else if(value <= 7)
            {
                toendeRamt = ToendeRamt[1];
            }
            else if (value <= 8)
            {
                toendeRamt = ToendeRamt[2];
            }
            else 
            {
                toendeRamt = ToendeRamt[3];
            }
            toendeRamt.Play();
        }

        #endregion

        #region Win

        private static SoundEffectInstance m_Win;
        private static SoundEffectInstance Win
        {
            get
            {
                if (m_Win == null)
                {
                    SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\Win");
                    m_Win = effect.CreateInstance();
                }
                return m_Win;
            }
        }
        public static void PlayWin()
        {
            Win.Play();
        }


        #endregion

        #region Barn

        private static List<SoundEffectInstance> m_Boern = new List<SoundEffectInstance>();

        private static List<SoundEffectInstance> Boern
        {
            get
            {
                if (m_Boern.Count == 0)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        SoundEffect effect = GameDevGame.Current.Content.Load<SoundEffect>(string.Format(@"Audio\Barn{0}", i));
                        m_Boern.Add(effect.CreateInstance());
                    }
                }
                return m_Boern;
            }
        }
        public static void PlayBarn()
        {
            int value = r.Next(0, 20);
            if(value <= 6)
            {
                Boern[value].Play();
            }
        }

        #endregion

    }
}
