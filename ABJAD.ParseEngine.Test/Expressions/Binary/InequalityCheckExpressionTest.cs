using System;
using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Binary;

public class InequalityCheckExpressionTest
{
    [Fact(DisplayName = "fails to instantiate if the operands are not of the same type")]
    public void fails_to_instantiate_if_the_operands_are_not_of_the_same_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        Assert.Throws<ArgumentException>(
            () => new InequalityCheckExpression(operand1.Object, operand2.Object));
    }
    
    [Fact(DisplayName = "fails to instantiate if the operands are void expressions")]
    public void fails_to_instantiate_if_the_operands_are_void_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Void());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Void());
        Assert.Throws<IllegalExpressionTypeException>(
            () => new InequalityCheckExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "has bool expression type")]
    public void has_bool_expression_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.String());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.String());
        var equalityCheckExpression = new InequalityCheckExpression(operand1.Object, operand2.Object);
        Assert.True(equalityCheckExpression.GetDataType().IsBool());
    }
}