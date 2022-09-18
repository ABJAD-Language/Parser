namespace ABJAD.ParseEngine.Expressions;

public class ToStringExpression : Expression
{
    public ToStringExpression(Expression target)
    {
        Target = target;
    }

    public Expression Target { get; }
}