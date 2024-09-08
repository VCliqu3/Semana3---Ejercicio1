using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IHasHealth
    {
        public void SetHealth(int health); 
        public int GetHealth();
        public int GetMaxHealth();
    }
}
