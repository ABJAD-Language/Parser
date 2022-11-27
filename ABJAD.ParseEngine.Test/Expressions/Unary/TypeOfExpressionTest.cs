using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Unary;

public class TypeOfExpressionTest
{
    [Fact(DisplayName = "has string expression return type")]
    public void has_string_expression_return_type()
    {
        var expression = new Mock<Expression>();
        expression.Setup(e => e.GetDataType()).Returns(DataType.Number());
        Assert.True(new TypeOfExpression(expression.Object).GetDataType().IsString());
    }
}