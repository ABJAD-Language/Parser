using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class ToStringExpression : Expression
{
    public ToStringExpression(Expression target)
    {
        if (!target.GetDataType().IsNumber() && !target.GetDataType().IsBool())
        {
            throw new InvalidExpressionTypeException(DataType.Bool(), DataType.Number());
        }
        
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        return DataType.String();
    }
}