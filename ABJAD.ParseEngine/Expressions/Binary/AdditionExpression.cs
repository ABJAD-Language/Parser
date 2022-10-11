using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class AdditionExpression : BinaryExpression
{
    public AdditionExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
    }

    public override DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}