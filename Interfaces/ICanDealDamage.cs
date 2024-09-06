using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface ICanDealDamage
    {
        public int GetDamage();
        public void DealDamage(IHasHealth iHasHealth);
    }
}
