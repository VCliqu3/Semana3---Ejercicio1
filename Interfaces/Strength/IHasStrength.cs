using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public interface IHasStrength
    {
        public void SetStrength(int srength);
        public int GetStrength();
        public int GetMaxStrength();
        public int GetMinStrength();

    }
}
