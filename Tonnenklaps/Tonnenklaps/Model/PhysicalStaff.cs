using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tonnenklaps.Util;

namespace Tonnenklaps.Model
{
    public class PhysicalStaff
    {
        public PossibleColors Color
        {
            get;
            set;
        }

        public bool Destroyed
        {
            get;
            set;
        }
    }
}
