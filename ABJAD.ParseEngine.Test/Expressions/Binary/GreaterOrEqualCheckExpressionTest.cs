﻿using System;
using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Binary;

public class GreaterOrEqualCheckExpressionTest
{
    [Fact(DisplayName = "fails to instantiate if the operands have different expression types")]
    public void fails_to_instantiate_if_the_operands_have_different_expression_types()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.String());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.Number());
        Assert.Throws<ArgumentException>(() => new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were boolean expressions")]
    public void fails_to_instantiate_if_the_operands_were_boolean_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        Assert.Throws<InvalidExpressionTypeException>(() => new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were custom typed expressions")]
    public void fails_to_instantiate_if_the_operands_were_custom_typed_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.Custom("type"));
        operand2.Setup(e => e.GetDataType()).Returns(DataType.Custom("type"));
        Assert.Throws<InvalidExpressionTypeException>(() => new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "fails to instantiate if the operands were void expressions")]
    public void fails_to_instantiate_if_the_operands_were_void_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.Void());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.Void());
        Assert.Throws<IllegalExpressionTypeException>(() => new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object));
    }

    [Fact(DisplayName = "does not fail to instantiate if the operands were number expressions")]
    public void does_not_fail_to_instantiate_if_the_operands_were_number_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.Number());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.Number());
        var greaterOrEqualCheckExpression = new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object);
        Assert.NotNull(greaterOrEqualCheckExpression);
    }

    [Fact(DisplayName = "does not fail to instantiate if the operands were string expressions")]
    public void does_not_fail_to_instantiate_if_the_operands_were_string_expressions()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.String());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.String());
        var greaterOrEqualCheckExpression = new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object);
        Assert.NotNull(greaterOrEqualCheckExpression);
    }

    [Fact(DisplayName = "has boolean expression type")]
    public void has_boolean_expression_type()
    {
        var operand1 = new Mock<Expression>();
        var operand2 = new Mock<Expression>();
        operand1.Setup(e => e.GetDataType()).Returns(DataType.String());
        operand2.Setup(e => e.GetDataType()).Returns(DataType.String());
        var greaterOrEqualCheckExpression = new GreaterOrEqualCheckExpression(operand1.Object, operand2.Object);
        Assert.True(greaterOrEqualCheckExpression.GetDataType().IsBool());
    }
}