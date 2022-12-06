using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions;

public class InvalidExpressionTypeException : ParsingException
{
    public DataType[] Target { get; }
    
    public InvalidExpressionTypeException(params DataType[] target) : base(GenerateEnglishMessage(target))
    {
        Target = target;
        EnglishMessage = GenerateEnglishMessage(target);
        ArabicMessage = GenerateArabicMessage(target);
    }

    private static string GenerateArabicMessage(params DataType[] target)
    {
        return $"من المطلوب أن يتوفر عبارة من نوع {GetTargetTypes(target)} لكنها لم توجد";
    }

    private static string GenerateEnglishMessage(params DataType[] target)
    {
        return $"Invalid expression type found; required one the following expression types: {GetTargetTypes(target)}.";
    }

    private static object GetTargetTypes(DataType[] target)
    {
        return $"[{string.Join(",", target.Select(t => t.GetValue()).ToList())}]";
    }
}