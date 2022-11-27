namespace ABJAD.ParseEngine.Types;

public interface DataType
{
    string GetValue();

    public static StringDataType String()
    {
        return new StringDataType();
    }

    public static NumberDataType Number()
    {
        return new NumberDataType();
    }

    public static BoolDataType Bool()
    {
        return new BoolDataType();  
    }

    public static VoidDataType Void()
    {
        return new VoidDataType();
    }

    public static CustomDataType Custom(string value)
    {
        return new CustomDataType(value);
    }

    public bool IsString()
    {
        return this is StringDataType;
    }

    public bool IsNumber()
    {
        return this is NumberDataType;
    }

    public bool IsBool()
    {
        return this is BoolDataType;
    }

    public bool IsVoid()
    {
        return this is VoidDataType;
    }

    public bool Is(string type)
    {
        return this is CustomDataType customDataType && customDataType.GetValue() == type;
    }

}