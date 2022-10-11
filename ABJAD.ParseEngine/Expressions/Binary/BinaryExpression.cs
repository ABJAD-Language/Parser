using ABJAD.ParseEngine.Types;
using Ardalis.GuardClauses;

namespace ABJAD.ParseEngine.Expressions.Binary;

public abstract class BinaryExpression : Expression
{
    protected BinaryExpression(Expression firstOperand, Expression secondOperand)
    {
        if (firstOperand.GetDataType() != secondOperand.GetDataType())
        {
            throw new ArgumentException("Binary expression operands should have the same type");
        }

        FirstOperand = firstOperand;
        SecondOperand = secondOperand;
    }

    public Expression FirstOperand { get; }
    public Expression SecondOperand { get; }

    public abstract DataType GetDataType();
}