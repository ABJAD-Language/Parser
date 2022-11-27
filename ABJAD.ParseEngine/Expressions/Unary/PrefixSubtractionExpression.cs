using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class PrefixSubtractionExpression : UnaryExpression
{
    public PrefixSubtractionExpression(Expression target) : base(target)
    {
        if (!target.GetDataType().IsNumber())
        {
            throw new InvalidExpressionTypeException(DataType.Number());
        }
    }

    public override DataType GetDataType()
    {
        return DataType.Number();
    }
}