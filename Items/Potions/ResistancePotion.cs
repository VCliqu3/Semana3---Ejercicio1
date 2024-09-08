using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1.Items
{
    public class ResistancePotion : Potion
    {
        public int resistance;

        private const int MAX_RESISTANCE = 2;

        public ResistancePotion(string name, int resistance) : base(name)
        {
            this.resistance = resistance;
        }

        public override int GetMaxStat() => MAX_RESISTANCE;
        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseResistance(resistance);
        }
    }
}
