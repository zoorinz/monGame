using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Types
{
    public abstract class GenericType : IType
    {
        // Nature, Water, Fire
        private int typeNr = -1;
        private List<TypeName> weakness = new List<TypeName>();
        private List<TypeName> strengths = new List<TypeName>();
        private List<TypeName> neutral = new List<TypeName>();
        // Nature, Water, Fire
        private readonly double[,] TYPE_MATRIX = new double[3, 3]
                                                {
                                                    {0.75, 1.5, 0.5},
                                                    {0.5, 0.75, 1.5 },
                                                    {1.5, 0.25, 0.75 }
                                                };

        protected void InitType(TypeName type)
        {
            this.typeNr = (int)type;
            TypeName[] typesArr = (TypeName[])Enum.GetValues(typeof(TypeName));
            TypeFabrik typeFabrik = new TypeFabrik();

            // Init strenghts, weakness and neutral
            for (int i = 0; i < Enum.GetNames(typeof(TypeName)).Length; i++)
            {
                IType currType = typeFabrik.CreateType(typesArr[i]);
                double values = this.TYPE_MATRIX[typeNr, i];
                //IType[] list = (IType[]) Enum.GetValues(typeof(TypeName));
                if (values > 1)
                    this.Strengths.Add(currType);
                else if (values == 0.75)
                    this.Neutrals.Add(currType);
                else
                    this.Weakness.Add(currType);

            }
            int j = 3 + 3;
        }

        public double[,] GetTypeMatrix()
        {
            return this.TYPE_MATRIX;
        }

        //TODO find a way to 
        /// <inheritdoc />
        public Dictionary<IType, double> TypeStregth { get; private set; }

        /// <inheritdoc />
        public List<IType> Weakness { get; private set; }

        /// <inheritdoc />
        public List<IType> Strengths { get; private set; }

        /// <inheritdoc />
        public List<IType> Neutrals { get; private set; }

        /// <inheritdoc />
        public abstract void Effect();
    }
}
