using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class ToBoolExpressionTest
{
    [Fact(DisplayName = "fails to instantiate when target expression type is not string")]
    public void fails_to_instantiate_when_target_expression_type_is_not_string()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        Assert.Throws<InvalidExpressionTypeException>(() => new ToBoolExpression(expression.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate when target expression type is string")]
    public void does_not_fail_to_instantiate_when_target_expression_type_is_string()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.String());
        var exception = Record.Exception(() => new ToBoolExpression(expression.Object));
        Assert.Null(exception);
    }

    [Fact(DisplayName = "has bool expression type")]
    public void has_bool_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.String());
        Assert.True(new ToBoolExpression(expression.Object).GetDataType().IsBool());
    }
}