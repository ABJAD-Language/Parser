﻿using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Expressions.Assignments;
using ABJAD.ParseEngine.Expressions.Binary;
using ABJAD.ParseEngine.Expressions.Unary;
using ABJAD.ParseEngine.Primitives;
using ABJAD.ParseEngine.Service.Expressions;
using ABJAD.ParseEngine.Service.Expressions.Assignments;
using ABJAD.ParseEngine.Service.Expressions.Binary;
using ABJAD.ParseEngine.Service.Expressions.Unary;
using ABJAD.ParseEngine.Service.Primitives;
using FluentAssertions;

namespace ABJAD.ParseEngine.Service.Test.Expressions;

public class ExpressionApiModelMapperTest
{
    [Fact(DisplayName = "maps call expression correctly")]
    public void maps_call_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new CallExpression(new PrimitiveExpression(BoolPrimitive.True()),
            new List<Expression>()));
        var expectedApiModel =
            new CallExpressionApiModel(new PrimitiveExpressionApiModel(new BoolPrimitiveApiModel(true)),
                new List<ExpressionApiModel>());
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps instance field expression correctly")]
    public void maps_instance_field_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new InstanceFieldExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("instance")),
            new List<PrimitiveExpression> { new(IdentifierPrimitive.From("field")) }));
        var expectedApiModel = new InstanceFieldExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("instance")),
            new List<PrimitiveExpressionApiModel>()
                { new(new IdentifierPrimitiveApiModel("field")) });
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps instance method call expression correctly")]
    public void maps_instance_method_call_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new InstanceMethodCallExpression(
            new List<PrimitiveExpression> { new(IdentifierPrimitive.From("instance")) },
            new PrimitiveExpression(IdentifierPrimitive.From("method")), new List<Expression>()));
        var expectedApiModel = new InstanceMethodCallExpressionApiModel(
            new List<PrimitiveExpressionApiModel>
                { new(new IdentifierPrimitiveApiModel("instance")) },
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("method")), new List<ExpressionApiModel>());
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps instantiation expression correctly")]
    public void maps_instantiation_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(
            new InstantiationExpression(new PrimitiveExpression(IdentifierPrimitive.From("class")), new List<Expression>()));
        var expectedApiModel = new InstantiationExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("class")), new List<ExpressionApiModel>());
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps primitive expression correctly")]
    public void maps_primitive_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new PrimitiveExpression(NumberPrimitive.From("2")));
        var expectedApiModel = new PrimitiveExpressionApiModel(new NumberPrimitiveApiModel(2));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps addition assignment expression correctly")]
    public void maps_addition_assignment_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new AdditionAssignmentExpression(IdentifierPrimitive.From("target"),
            new PrimitiveExpression(NumberPrimitive.From("3"))));
        var expectedApiModel = new AdditionAssignmentExpressionApiModel(new IdentifierPrimitiveApiModel("target"),
            new PrimitiveExpressionApiModel(new NumberPrimitiveApiModel(3)));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps subtraction assignment expression correctly")]
    public void maps_subtraction_assignment_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new SubtractionAssignmentExpression(IdentifierPrimitive.From("target"),
            new PrimitiveExpression(NumberPrimitive.From("3"))));
        var expectedApiModel = new SubtractionAssignmentExpressionApiModel(new IdentifierPrimitiveApiModel("target"),
            new PrimitiveExpressionApiModel(new NumberPrimitiveApiModel(3)));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps multiplication assignment expression correctly")]
    public void maps_multiplication_assignment_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new MultiplicationAssignmentExpression(IdentifierPrimitive.From("target"),
            new PrimitiveExpression(NumberPrimitive.From("3"))));
        var expectedApiModel = new MultiplicationAssignmentExpressionApiModel(new IdentifierPrimitiveApiModel("target"),
            new PrimitiveExpressionApiModel(new NumberPrimitiveApiModel(3)));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps division assignment expression correctly")]
    public void maps_division_assignment_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new DivisionAssignmentExpression(IdentifierPrimitive.From("target"),
            new PrimitiveExpression(NumberPrimitive.From("3"))));
        var expectedApiModel = new DivisionAssignmentExpressionApiModel(new IdentifierPrimitiveApiModel("target"),
            new PrimitiveExpressionApiModel(new NumberPrimitiveApiModel(3)));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps negation expression correctly")]
    public void maps_negation_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new NegationExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new NegationExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps negative expression correctly")]
    public void maps_negative_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new NegativeExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new NegativeExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps postfix addition expression correctly")]
    public void maps_postfix_addition_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new PostfixAdditionExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new PostfixAdditionExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps postfix subtraction expression correctly")]
    public void maps_postfix_subtraction_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new PostfixSubtractionExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new PostfixSubtractionExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps prefix addition expression correctly")]
    public void maps_prefix_addition_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new PrefixAdditionExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new PrefixAdditionExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps prefix subtraction expression correctly")]
    public void maps_prefix_subtraction_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new PrefixSubtractionExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new PrefixSubtractionExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps to bool expression correctly")]
    public void maps_to_bool_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new ToBoolExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new ToBoolExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps to number expression correctly")]
    public void maps_to_number_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new ToNumberExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new ToNumberExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps to string expression correctly")]
    public void maps_to_string_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new ToStringExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new ToStringExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps typeof expression correctly")]
    public void maps_typeof_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new TypeOfExpression(new PrimitiveExpression(IdentifierPrimitive.From("target"))));
        var expectedApiModel = new TypeofExpressionApiModel(new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("target")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps addition expression correctly")]
    public void maps_addition_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new AdditionExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new AdditionExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps subtraction expression correctly")]
    public void maps_subtraction_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new SubtractionExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new SubtractionExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps multiplication expression correctly")]
    public void maps_multiplication_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new MultiplicationExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new MultiplicationExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps division expression correctly")]
    public void maps_division_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new DivisionExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new DivisionExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps modulo expression correctly")]
    public void maps_modulo_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new ModuloExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new ModuloExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps and operation expression correctly")]
    public void maps_and_operation_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new AndOperationExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new AndOperationExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps or operation expression correctly")]
    public void maps_or_operation_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new OrOperationExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new OrOperationExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps equality check expression correctly")]
    public void maps_equality_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new EqualityCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new EqualityCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps inequality check expression correctly")]
    public void maps_inequality_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new InequalityCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new InequalityCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps greater check expression correctly")]
    public void maps_greater_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new GreaterCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new GreaterCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps greater or equal check expression correctly")]
    public void maps_greater_or_equal_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new GreaterOrEqualCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new GreaterOrEqualCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps less check expression correctly")]
    public void maps_less_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new LessCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new LessCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }

    [Fact(DisplayName = "maps less or equal check expression correctly")]
    public void maps_less_or_equal_check_expression_correctly()
    {
        var expressionApiModel = ExpressionApiModelMapper.Map(new LessOrEqualCheckExpression(
            new PrimitiveExpression(IdentifierPrimitive.From("operand1")),
            new PrimitiveExpression(IdentifierPrimitive.From("operand2"))));
        var expectedApiModel = new LessOrEqualCheckExpressionApiModel(
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand1")),
            new PrimitiveExpressionApiModel(new IdentifierPrimitiveApiModel("operand2")));
        expressionApiModel.Should().BeEquivalentTo(expectedApiModel, options => options.RespectingRuntimeTypes());
    }
}