using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
    }

    public override DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}