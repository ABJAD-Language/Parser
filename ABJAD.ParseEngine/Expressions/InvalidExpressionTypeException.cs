using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions;

public class InvalidExpressionTypeException : ParsingException
{
    public DataType Target { get; }
    
    public InvalidExpressionTypeException(DataType target) : base(GenerateEnglishMessage(target))
    {
        Target = target;
        EnglishMessage = GenerateEnglishMessage(target);
        ArabicMessage = GenerateArabicMessage(target);
    }

    private static string GenerateArabicMessage(DataType target)
    {
        return $"من المطلوب أن يتوفر عبارة من نوع {target.GetValue()} لكنها لم توجد";
    }

    private static string GenerateEnglishMessage(DataType target)
    {
        return $"Invalid expression type found; required {target.GetValue()} expression.";
    }
}