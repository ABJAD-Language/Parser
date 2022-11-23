﻿namespace ABJAD.ParseEngine.Service.Primitives;

public class NumberPrimitiveApiModel : PrimitiveExpressionApiModel
{
    public double Value { get; }

    public NumberPrimitiveApiModel(double value)
    {
        Value = value;
        Type = "primitive.number";
    }
}