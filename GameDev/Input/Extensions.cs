using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameDev.Input
{
    public static class Extensions
    {
        private static DateTime m_Then = DateTime.MinValue;

        public static TimeSpan TotalRealTime(this GameTime time)
        {
            if (m_Then == DateTime.MinValue)
            {
                m_Then = DateTime.Now;
                return new TimeSpan(0, 0, 0, 0, 0);
            }

            return DateTime.Now.Subtract(m_Then);
        }
    }
}
