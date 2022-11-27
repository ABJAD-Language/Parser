using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class NegativeExpressionTest
{
    [Fact(DisplayName = "fails to instantiate when the target is not a number")]
    public void fails_to_instantiate_when_the_target_is_not_a_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Custom(""));
        
        Assert.Throws<InvalidExpressionTypeException>(() => new NegativeExpression(expression.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate when target is a number")]
    public void does_not_fail_to_instantiate_when_target_is_a_number()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        
        var exception = Record.Exception(() => new NegativeExpression(expression.Object));
        Assert.Null(exception);
    }

    [Fact(DisplayName = "has number expression type")]
    public void has_number_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        
        Assert.True(new NegativeExpression(expression.Object).GetDataType().IsNumber());
    }
    
}