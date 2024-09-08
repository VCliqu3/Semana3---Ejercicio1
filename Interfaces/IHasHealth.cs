using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IHasHealth
    {
        public bool TakeDamage(int quantity);
        public void IncreaseHealth(int quantity);
        public int GetHealth();
        public bool IsAlive();
    }
}
