using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Assignments;
using ABJAD.ParseEngine.Primitives;
using ABJAD.ParseEngine.Types;
using FluentAssertions;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Assignments;

public class BinaryAssignmentExpressionTest
{
    private readonly Mock<Expression> expressionMock = new();
    
    [Fact]
    private void HasVoidReturnType()
    {
        var expression = new AdditionAssignmentExpression(IdentifierPrimitive.From("id"), expressionMock.Object);
        expression.GetDataType().Should().BeOfType(typeof(VoidDataType));
    }
}