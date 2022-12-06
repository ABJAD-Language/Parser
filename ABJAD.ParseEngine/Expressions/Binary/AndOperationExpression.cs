using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class AndOperationExpression : BinaryLogicalExpression
{
    public AndOperationExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
        if (!firstOperand.GetDataType().IsBool())
        {
            throw new InvalidExpressionTypeException(DataType.Bool());
        }
    }
}