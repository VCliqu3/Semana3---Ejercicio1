﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Item
    {
        public string name;
        public Item(string name)
        {
            this.name = name;
        }

        public abstract int GetMaxStat();
    }
}
