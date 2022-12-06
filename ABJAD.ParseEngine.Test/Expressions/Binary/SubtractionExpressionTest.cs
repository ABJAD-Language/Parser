﻿using System;
using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Types;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Expressions.Binary;

public class SubtractionExpressionTest
{
     [Fact(DisplayName = "does not fail to instantiate when both operands are numbers")]
    public void does_not_fail_to_instantiate_when_both_operands_are_numbers()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Number());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.Number());
        
        Assert.NotNull(new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "fails to instantiate when operands are booleans")]
    public void fails_to_instantiate_when_operands_are_booleans()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Bool());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.Bool());

        Assert.Throws<InvalidExpressionTypeException>(() =>
            new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "fails to instantiate when operands are strings")]
    public void fails_to_instantiate_when_operands_are_strings()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.String());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.String());

        Assert.Throws<InvalidExpressionTypeException>(() =>
            new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "fails to instantiate when operands have custom expression type")]
    public void fails_to_instantiate_when_operands_have_custom_expression_type()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Custom("custom"));
        expression2.Setup(e => e.GetDataType()).Returns(DataType.Custom("custom"));

        Assert.Throws<InvalidExpressionTypeException>(() =>
            new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "fails to instantiate when operands have void expression type")]
    public void fails_to_instantiate_when_operands_have_void_expression_type()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Void());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.Void());

        Assert.Throws<IllegalExpressionTypeException>(() =>
            new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "fails to instantiate when operands have different types")]
    public void fails_to_instantiate_when_operands_have_different_types()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Number());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.String());

        Assert.Throws<ArgumentException>(() =>
            new SubtractionExpression(expression1.Object, expression2.Object));
    }

    [Fact(DisplayName = "has number expression type")]
    public void has_number_expression_type()
    {
        var expression1 = new Mock<Expression>();
        var expression2 = new Mock<Expression>();
        expression1.Setup(e => e.GetDataType()).Returns(DataType.Number());
        expression2.Setup(e => e.GetDataType()).Returns(DataType.Number());
        
        Assert.True(new SubtractionExpression(expression1.Object, expression2.Object).GetDataType().IsNumber());
    }
}