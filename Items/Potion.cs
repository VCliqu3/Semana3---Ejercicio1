﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Potion : Item
    {
        public Potion(string name) : base(name) { }

        public abstract void ApplyPotion(Entity entity);

    }
}
