namespace ABJAD.ParseEngine.Types;

public class StringDataType : DataType
{
    public string GetValue()
    {
        return "STRING";
    }

    public override bool Equals(object? obj)
    {
        return obj != null && obj is StringDataType;
    }

    public override int GetHashCode()
    {
        return GetValue().GetHashCode();
    }
}