using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class LessCheckExpression : BinaryLogicalExpression
{
    public LessCheckExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
        if (!firstOperand.GetDataType().IsNumber() && !firstOperand.GetDataType().IsString())
        {
            throw new InvalidExpressionTypeException(DataType.Number(), DataType.String());
        }
    }
}