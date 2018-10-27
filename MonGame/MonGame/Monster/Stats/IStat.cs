using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonGame.Monster.Stats
{
    interface IStat
    {
        double Attack { get; }
        double Defence { get; }
        double Speed { get; }
        void LvlUp();
    }
}
