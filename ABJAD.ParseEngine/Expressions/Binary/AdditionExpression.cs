using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class AdditionExpression : BinaryExpression
{
    public AdditionExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
        if (!OperandsAreNumbers(firstOperand, secondOperand) && !OperandsAreStrings(firstOperand, secondOperand))
        {
            throw new InvalidExpressionTypeException(DataType.Number(), DataType.String());
        }
    }

    public override DataType GetDataType()
    {
        return FirstOperand.GetDataType();
    }

    private static bool OperandsAreStrings(Expression firstOperand, Expression secondOperand)
    {
        return firstOperand.GetDataType().IsString() && secondOperand.GetDataType().IsString();
    }

    private static bool OperandsAreNumbers(Expression firstOperand, Expression secondOperand)
    {
        return firstOperand.GetDataType().IsNumber() && secondOperand.GetDataType().IsNumber();
    }
}