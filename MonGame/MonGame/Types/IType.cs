using System;
using System.Collections.Generic;

public interface IType
{
    Dictionary<IType, double> TypeStregth { get; }
    List<IType> Weakness { get; }
    List<IType> Strengths{ get; }
    List<IType> Neutrals { get; }


    void Effect();
}
