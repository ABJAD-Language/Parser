using System;
using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Binary;

public class DivisionExpressionTest
{
    [Fact(DisplayName = "fails to instantiate if operands did not have the same type")]
    public void fails_to_instantiate_if_operands_did_not_have_the_same_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        Assert.Throws<ArgumentException>(() => new DivisionExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were bool expressions")]
    public void fails_to_instantiate_if_the_operands_were_bool_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Bool());
        Assert.Throws<InvalidExpressionTypeException>(
            () => new DivisionExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were string expressions")]
    public void fails_to_instantiate_if_the_operands_were_string_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.String());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.String());
        Assert.Throws<InvalidExpressionTypeException>(
            () => new DivisionExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were void expressions")]
    public void fails_to_instantiate_if_the_operands_were_void_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Void());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Void());
        Assert.Throws<IllegalExpressionTypeException>(
            () => new DivisionExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were custom typed expressions")]
    public void fails_to_instantiate_if_the_operands_were_custom_typed_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Custom("type"));
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Custom("type"));
        Assert.Throws<InvalidExpressionTypeException>(
            () => new DivisionExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate when the operands are number expressions")]
    public void does_not_fail_to_instantiate_when_the_operands_are_number_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Number());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        var divisionExpression = new DivisionExpression(operand1.Object, operand2.Object);
        Assert.NotNull(divisionExpression);
    }

    [Fact(DisplayName = "has number expression type")]
    public void has_number_expression_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(o => o.GetDataType()).Returns(DataType.Number());
        operand2.Setup(o => o.GetDataType()).Returns(DataType.Number());
        var divisionExpression = new DivisionExpression(operand1.Object, operand2.Object);
        Assert.True(divisionExpression.GetDataType().IsNumber());
    }
}