﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class StrengthPotion : Potion
    {
        public int strength;

        private const int MAX_STRENGTH = 2;

        public StrengthPotion(string name, int strength) : base(name)
        {
            this.strength = strength;
        }

        public override int GetMaxStat() => MAX_STRENGTH;
    }
}
