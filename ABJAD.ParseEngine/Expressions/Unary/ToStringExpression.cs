using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class ToStringExpression : Expression
{
    public ToStringExpression(Expression target)
    {
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}