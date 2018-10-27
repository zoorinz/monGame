using System;

public interface IType
{
    public Dictionary<IType, double> TypeStregthness { get; };

    public List<IType> Weakness();
    public List<IType> Strengths();
    public void effect();
}
