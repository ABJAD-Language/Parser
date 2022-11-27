using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class PostfixAdditionExpressionTest
{
    [Fact(DisplayName = "fails to instantiate if the target expression type is not number")]
    public void fails_to_instantiate_if_the_target_expression_type_is_not_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(new StringDataType());
        Assert.Throws<InvalidExpressionTypeException>(() => new PostfixAdditionExpression(expression.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate when the target expression type is number")]
    public void does_not_fail_to_instantiate_when_the_target_expression_type_is_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(new NumberDataType());
        var exception = Record.Exception(() => new PostfixAdditionExpression(expression.Object));
        Assert.Null(exception);
    }

    [Fact(DisplayName = "has number expression type")]
    public void has_number_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(new NumberDataType());
        Assert.True(new PostfixAdditionExpression(expression.Object).GetDataType().IsNumber());
    }
}