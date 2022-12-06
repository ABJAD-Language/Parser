using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Binary;

public class ModuloExpression : BinaryExpression
{
    public ModuloExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
        if (!firstOperand.GetDataType().IsNumber())
        {
            throw new InvalidExpressionTypeException(DataType.Number());
        }
    }

    public override DataType GetDataType()
    {
        return DataType.Number();
    }
}