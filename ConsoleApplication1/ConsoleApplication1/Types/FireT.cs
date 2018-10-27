using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Types
{
    public class FireT : GenericType
    {
        private TypeName name = TypeName.Nature;
        /// <inheritdoc />
        public FireT() : base()
            {
            base.InitType(name);
        }


        /// <inheritdoc />
        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
