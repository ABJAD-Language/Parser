using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Unary;

public class ToBoolExpression : Expression
{
    public ToBoolExpression(Expression target)
    {
        if (!target.GetDataType().IsString())
        {
            throw new InvalidExpressionTypeException(DataType.String());
        }
        
        Target = target;
    }

    public Expression Target { get; }

    public DataType GetDataType()
    {
        return DataType.Bool();
    }
}