﻿namespace ABJAD.ParseEngine.Service.Expressions.Binary;

public class SubtractionExpressionApiModel : BinaryExpressionApiModel
{
    public SubtractionExpressionApiModel(ExpressionApiModel firstOperand, ExpressionApiModel secondOperand) : base("expression.subtraction", firstOperand, secondOperand)
    {
    }
}