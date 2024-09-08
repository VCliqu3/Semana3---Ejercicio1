using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class AgilityPotion : Potion, IHasAgility
    {
        public int agility;

        private const int MAX_AGILITY = 2;

        public AgilityPotion(string name, int agility) : base(name)
        {
            this.agility = agility;
        }

        public override int GetMaxStat() => MAX_AGILITY;

        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseAgility(agility);
        }

        public void SetAgility(int agility) => this.agility = agility;
        public int GetAgility() => agility;
        public int GetMaxAgility() => MAX_AGILITY;
    }
}
