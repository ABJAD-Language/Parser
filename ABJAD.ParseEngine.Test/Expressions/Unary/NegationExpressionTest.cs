using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class NegationExpressionTest
{
    [Fact(DisplayName = "fails to instantiates when target is not a boolean expression")]
    public void fails_to_instantiates_when_target_is_not_a_boolean_expression()
    {
        Assert.Throws<InvalidExpressionTypeException>(() =>
        {
            var expression = new Mock<Expression>();
            expression.Setup(e => e.GetDataType()).Returns(DataType.String());
            return new NegationExpression(expression.Object);
        });
    }

    [Fact(DisplayName = "does not fail to instantiate when target is a boolean expression")]
    public void does_not_fail_to_instantiate_when_target_is_a_boolean_expression()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        var exception = Record.Exception(() => new NegationExpression(expression.Object));
        Assert.Null(exception);
    }

    [Fact(DisplayName = "has boolean expression type")]
    public void has_boolean_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        Assert.True(new NegationExpression(expression.Object).GetDataType().IsBool());
    }
}