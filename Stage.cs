using System;
using System.Collections.Generic;
using System.Text;

namespace Semana3___Ejercicio1
{
    public class Stage
    {
        public int number;
        public List<Enemy> enemies;

        public Stage(int number, List<Enemy> enemies)
        {
            this.number = number;
            this.enemies = enemies;
        }

        public bool StageEnded()
        {
            foreach(Enemy enemy in enemies)
            {
                if (enemy.IsAlive()) return false;
            }

            return true;
        }
    }
}
