using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Types
{
    public class TypeFabrik
    {
        public GenericType CreateType(TypeName name) {
            switch (name)
            {
                case TypeName.Nature:
                    return new NatureT();
                case TypeName.Fire:
                    return new FireT();
                case TypeName.Water:
                    return new WaterT();
            }
            throw new NotImplementedException("Type not implemented yet " + name.ToString() );
        }
    }
}
