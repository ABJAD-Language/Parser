﻿namespace ABJAD.ParseEngine.Service.Expressions.Unary;

public class NegativeExpressionApiModel : UnaryExpressionApiModel
{
    public NegativeExpressionApiModel(ExpressionApiModel target) : base("expression.negative", target)
    {
    }
}