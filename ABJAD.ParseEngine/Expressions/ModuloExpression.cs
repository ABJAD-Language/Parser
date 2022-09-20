namespace ABJAD.ParseEngine.Expressions;

public class ModuloExpression : BinaryExpression
{
    public ModuloExpression(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand)
    {
    }
}