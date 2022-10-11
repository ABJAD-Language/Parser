using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class ToBoolExpression : Expression
{
    public ToBoolExpression(Expression target)
    {
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}