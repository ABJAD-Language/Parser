using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class ToStringExpressionTest
{
    [Fact(DisplayName = "fails to instantiate when target is a void expression")]
    public void fails_to_instantiate_when_target_is_a_void_expression()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Void());
        Assert.Throws<InvalidExpressionTypeException>(() => new ToStringExpression(expression.Object));
    }
    
    [Fact(DisplayName = "fails to instantiate when target is a custom expression")]
    public void fails_to_instantiate_when_target_is_a_custom_expression()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Custom("type"));
        Assert.Throws<InvalidExpressionTypeException>(() => new ToStringExpression(expression.Object));
    }
    
    [Fact(DisplayName = "fails to instantiate when target is a string expression")]
    public void fails_to_instantiate_when_target_is_a_string_expression()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.String());
        Assert.Throws<InvalidExpressionTypeException>(() => new ToStringExpression(expression.Object));
    }

    [Fact(DisplayName = "has string expression type")]
    public void has_string_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        Assert.True(new ToStringExpression(expression.Object).GetDataType().IsString());
    }
}