﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IAgilityBeing : IHasAgility
    {
        public void IncreaseAgility(int agility);
        public bool CheckEvasion();
    }
}
