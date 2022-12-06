namespace ABJAD.ParseEngine.Types;

public class NumberDataType : DataType
{
    public string GetValue()
    {
        return "NUMBER";
    }
    
    public override bool Equals(object? obj)
    {
        return obj is NumberDataType;
    }

    public override int GetHashCode()
    {
        return GetValue().GetHashCode();
    }
}