using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class ResistancePotion : Potion, IHasResistance
    {
        public int resistance;

        private const int MAX_RESISTANCE = 2;
        private const int MIN_RESISTANCE = 1;

        public ResistancePotion(string name, int resistance) : base(name)
        {
            this.resistance = resistance;
        }

        public override int GetMaxStat() => MAX_RESISTANCE;
        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseResistance(resistance);
        }

        public void SetResistance(int resistance) => this.resistance = resistance;
        public int GetResistance() => resistance;
        public int GetMaxResistance() => MAX_RESISTANCE;
        public int GetMinResistance() => MIN_RESISTANCE;
    }
}
