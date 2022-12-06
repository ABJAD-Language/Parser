namespace ABJAD.ParseEngine.Types;

public class CustomDataType : DataType
{
    private readonly string value;

    public CustomDataType(string value)
    {
        this.value = value;
    }

    public string GetValue()
    {
        return value;
    }
    public override bool Equals(object? obj)
    {
        return obj is CustomDataType customDataType && value == customDataType.GetValue();
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }
}