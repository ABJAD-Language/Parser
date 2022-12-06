using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
        if (!firstOperand.GetDataType().IsNumber())
        {
            throw new InvalidExpressionTypeException(DataType.Number(), DataType.String());
        }
    }

    public override DataType GetDataType()
    {
        return DataType.Number();
    }
}