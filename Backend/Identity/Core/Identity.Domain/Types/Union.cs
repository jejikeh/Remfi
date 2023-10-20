namespace Identity.Domain.Types;

public struct Union<TValue0, TValue1>
{
    public TValue0 Value0 { get; }
    public TValue1 Value1 { get; }
    
    public Union(TValue0 value0, TValue1 value1)
    {
        Value0 = value0;
        Value1 = value1;
    }
}

public struct Union<TValue0, TValue1, TValue2>
{
    public TValue0 Value0 { get; }
    public TValue1 Value1 { get; }
    public TValue2 Value2 { get; }
    
    public Union(TValue0 value0, TValue1 value1, TValue2 value2)
    {
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }
}

public struct Union<TValue0, TValue1, TValue2, TValue3> 
{
    public TValue0 Value0 { get; }
    public TValue1 Value1 { get; }
    public TValue2 Value2 { get; }
    public TValue3 Value3 { get; }
    
    public Union(TValue0 value0, TValue1 value1, TValue2 value2, TValue3 value3)
    {
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
        Value3 = value3;
    }
}

