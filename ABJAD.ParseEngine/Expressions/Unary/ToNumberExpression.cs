using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class ToNumberExpression : Expression
{
    public ToNumberExpression(Expression target)
    {
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}