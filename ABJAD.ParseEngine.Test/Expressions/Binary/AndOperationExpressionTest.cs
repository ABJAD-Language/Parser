using System;
using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Binary;

public class AndOperationExpressionTest
{
    [Fact(DisplayName = "fails to instantiate if the operands are not of the same type")]
    public void fails_to_instantiate_if_the_operands_are_not_of_the_same_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        Assert.Throws<ArgumentException>(
            () => new AndOperationExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands are number expressions")]
    public void fails_to_instantiate_if_the_operands_are_number_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Number());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        Assert.Throws<InvalidExpressionTypeException>(
            () => new AndOperationExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands are string expressions")]
    public void fails_to_instantiate_if_the_operands_are_string_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.String());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.String());
        Assert.Throws<InvalidExpressionTypeException>(
            () => new AndOperationExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands are void expressions")]
    public void fails_to_instantiate_if_the_operands_are_void_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Void());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Void());
        Assert.Throws<IllegalExpressionTypeException>(
            () => new AndOperationExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands are custom typed expressions")]
    public void fails_to_instantiate_if_the_operands_are_custom_typed_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Custom("type"));
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Custom("type"));
        Assert.Throws<InvalidExpressionTypeException>(
            () => new AndOperationExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate if the operands are bool expressions")]
    public void does_not_fail_to_instantiate_if_the_operands_are_bool_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        var andOperationExpression = new AndOperationExpression(operand1.Object, operand2.Object);
        Assert.NotNull(andOperationExpression);
    }

    [Fact(DisplayName = "has bool return type")]
    public void has_bool_return_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        var andOperationExpression = new AndOperationExpression(operand1.Object, operand2.Object);
        Assert.True(andOperationExpression.GetDataType().IsBool());
    }
}