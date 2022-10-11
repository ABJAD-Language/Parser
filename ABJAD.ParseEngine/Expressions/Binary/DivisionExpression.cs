using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class DivisionExpression : BinaryExpression
{
    public DivisionExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
    }

    public override DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}