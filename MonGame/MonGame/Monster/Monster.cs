using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonGame.Monster.Stats;

namespace MonGame.Monster
{
    public class Monster
    {
        public Monster(Stat stats, string name) {
            this.Stat = stats;
            this.Name = name;
        }

        public Stat Stat { get; }
        public string Name { get; }
    }
}
