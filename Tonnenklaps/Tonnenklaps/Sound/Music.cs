using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using GameDev.Utils;
using Microsoft.Xna.Framework.Media;

namespace Tonnenklaps.Sound
{
    public static class Music
    {
        private static Song m_MenuTune;
        private static Song m_GameTune;


        public static Song GetMenuTune()
        {
            if (m_MenuTune == null)
            {

                m_MenuTune = GameDevGame.Current.Content.Load<Song>(@"Audio\MenuTheme");
            }
            return m_MenuTune;
        }

        public static Song GetGameTune()
        {
            if (m_GameTune == null)
            {
                m_GameTune = GameDevGame.Current.Content.Load<Song>(@"Audio\Beat");
            }
            return m_GameTune;
        }

    }
}
