using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class StrengthPotion : Potion, IHasStrength
    {
        public int strength;

        private const int MAX_STRENGTH = 2;

        public StrengthPotion(string name, int strength) : base(name)
        {
            this.strength = strength;
        }

        public override int GetMaxStat() => MAX_STRENGTH;

        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseStrength(strength);
        }

        public void SetStrength(int strength) => this.strength = strength;

        public int GetStrength() => strength;

        public int GetMaxStrength() => MAX_STRENGTH;

    }
}
