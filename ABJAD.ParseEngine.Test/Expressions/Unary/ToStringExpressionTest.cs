using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class ToStringExpressionTest
{
    [Fact(DisplayName = "has string expression type")]
    public void has_string_expression_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        Assert.True(new ToStringExpression(expression.Object).GetDataType().IsString());
    }
}