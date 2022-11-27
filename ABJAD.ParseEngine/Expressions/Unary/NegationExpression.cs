using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class NegationExpression : UnaryExpression
{
    public NegationExpression(Expression target) : base(target)
    {
        if (!target.GetDataType().IsBool())
        {
            throw new InvalidExpressionTypeException(DataType.Bool());
        }
    }

    public override DataType GetDataType()
    {
        return DataType.Bool();
    }
}