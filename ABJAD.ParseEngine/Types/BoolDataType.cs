namespace ABJAD.ParseEngine.Types;

public class BoolDataType : DataType
{
    public string GetValue()
    {
        return "BOOL";
    }
    
    public override bool Equals(object? obj)
    {
        return obj is BoolDataType;
    }

    public override int GetHashCode()
    {
        return GetValue().GetHashCode();
    }
}