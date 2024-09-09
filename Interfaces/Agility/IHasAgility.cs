using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IHasAgility
    {
        public void SetAgility(int agility);
        public int GetAgility();
        public int GetMaxAgility();
        public int GetMinAgility();

    }
}
