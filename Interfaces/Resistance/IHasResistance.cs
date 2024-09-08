using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IHasResistance
    {
        public void SetResistance(int resistance);
        public int GetResistance();
        public int GetMaxResistance();
    }
}
