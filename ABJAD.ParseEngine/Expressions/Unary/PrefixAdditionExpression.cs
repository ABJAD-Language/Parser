using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class PrefixAdditionExpression : UnaryExpression
{
    public PrefixAdditionExpression(Expression target) : base(target) // TODO make target IdentifierPrimitive
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