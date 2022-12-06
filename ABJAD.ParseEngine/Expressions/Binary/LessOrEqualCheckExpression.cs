using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class LessOrEqualCheckExpression : BinaryLogicalExpression
{
    public LessOrEqualCheckExpression(Expression firstOperand, Expression secondOperand) 
        : base(firstOperand, secondOperand)
    {
        if (!firstOperand.GetDataType().IsNumber() && !firstOperand.GetDataType().IsString())
        {
            throw new InvalidExpressionTypeException(DataType.Number(), DataType.String());
        }
    }
}