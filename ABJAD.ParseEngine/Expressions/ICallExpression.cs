
namespace ABJAD.ParseEngine.Expressions
{
    public interface ICallExpression
    {
        List<Expression> Arguments { get; }
        PrimitiveExpression Method { get; }
    }
}