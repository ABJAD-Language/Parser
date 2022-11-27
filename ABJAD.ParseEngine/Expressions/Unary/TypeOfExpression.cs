using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class TypeOfExpression : Expression
{
    public TypeOfExpression(Expression target)
    {
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        return DataType.String();
    }
}