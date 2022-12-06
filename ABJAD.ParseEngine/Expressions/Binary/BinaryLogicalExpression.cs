using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class BinaryLogicalExpression : BinaryExpression
{
    public BinaryLogicalExpression(Expression firstOperand, Expression secondOperand) 
        : base(firstOperand, secondOperand)
    {
    }

    public override DataType GetDataType()
    {
        return DataType.Bool();
    }
}