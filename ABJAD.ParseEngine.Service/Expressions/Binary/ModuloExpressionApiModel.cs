namespace ABJAD.ParseEngine.Service.Expressions.Binary;

public class ModuloExpressionApiModel : BinaryExpressionApiModel
{
    public ModuloExpressionApiModel(ExpressionApiModel firstOperand, ExpressionApiModel secondOperand) : base("modulo", firstOperand, secondOperand)
    {
    }
}