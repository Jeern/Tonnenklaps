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
        private static Dictionary<PlayerIndex,  SoundEffect > PlayerPointSound = new Dictionary<PlayerIndex, SoundEffect>();
        static Sounds()
        {
             PlayerPointSound.Add( PlayerIndex.One, GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP1"));
             PlayerPointSound.Add(PlayerIndex.Two, GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP2"));
             PlayerPointSound.Add(PlayerIndex.Three , GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP3"));
             PlayerPointSound.Add(PlayerIndex.Four, GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\PointP4"));
        }
        private static Random r = new Random();

        #region Point sounds

        public static void PlayPoint(PlayerIndex index)
        {

            PlayerPointSound[index].Play();

        }

        #endregion

        #region MenuKlik sounds

        private static SoundEffect m_MenuKlik;
        private static SoundEffect MenuKlik
        {
            get
            {
                if (m_MenuKlik == null)
                {
                    m_MenuKlik = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\MenuKlik");
                }
                return m_MenuKlik;
            }
        }
        public static void PlayMenuKlik()
        {
            MenuKlik.Play();
        }

        private static SoundEffect m_MenuKlikDyb;
        private static SoundEffect MenuKlikDyb
        {
            get
            {
                if (m_MenuKlikDyb == null)
                {
                    m_MenuKlikDyb = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\MenuKlikDyb");
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

        private static List<SoundEffect> m_ToendeRamt = new List<SoundEffect>();

        private static List<SoundEffect> ToendeRamt
        {
            get
            {
                if (m_ToendeRamt.Count == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        m_ToendeRamt.Add(GameDevGame.Current.Content.Load<SoundEffect>(string.Format(@"Audio\TondeRamt{0}", i)));
                    }
                }
                return m_ToendeRamt;
            }
        }
        public static void PlayToendeRamt()
        {
            int value = r.Next(10);
            SoundEffect toendeRamt;

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

        private static SoundEffect m_Win;
        private static SoundEffect Win
        {
            get
            {
                if (m_Win == null)
                {
                    m_Win = GameDevGame.Current.Content.Load<SoundEffect>(@"Audio\Win");
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

        private static List<SoundEffect> m_Boern = new List<SoundEffect>();

        private static List<SoundEffect> Boern
        {
            get
            {
                if (m_Boern.Count == 0)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        m_Boern.Add(GameDevGame.Current.Content.Load<SoundEffect>(string.Format(@"Audio\Barn{0}", i)));
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
