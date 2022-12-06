namespace ABJAD.ParseEngine.Types;

public class VoidDataType : DataType
{
    public string GetValue()
    {
        return "VOID";
    }
    
    public override bool Equals(object? obj)
    {
        return obj is VoidDataType;
    }

    public override int GetHashCode()
    {
        return GetValue().GetHashCode();
    }
}