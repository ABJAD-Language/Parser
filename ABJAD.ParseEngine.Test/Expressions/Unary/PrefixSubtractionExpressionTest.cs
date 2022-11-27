using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class PrefixSubtractionExpressionTest
{
    [Fact(DisplayName = "fails to instantiate when target expression type is not number")]
    public void fails_to_instantiate_when_target_expression_type_is_not_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        Assert.Throws<InvalidExpressionTypeException>(() => new PrefixSubtractionExpression(expression.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate when target expression type is number")]
    public void does_not_fail_to_instantiate_when_target_expression_type_is_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        var exception = Record.Exception(() => new PrefixSubtractionExpression(expression.Object));
        Assert.Null(exception);
    }

    [Fact(DisplayName = "has number expression type")]
    public void has_number_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        Assert.True(new PrefixSubtractionExpression(expression.Object).GetDataType().IsNumber());
    }
}