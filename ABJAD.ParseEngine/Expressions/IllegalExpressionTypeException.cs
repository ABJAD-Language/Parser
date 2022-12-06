using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions;

public class IllegalExpressionTypeException : ParsingException
{
    public DataType Target { get; }
    
    public IllegalExpressionTypeException(DataType target) : base(GenerateEnglishMessage(target))
    {
        Target = target;
        EnglishMessage = GenerateEnglishMessage(target);
        ArabicMessage = GenerateArabicMessage(target);
    }

    private static string GenerateArabicMessage(DataType target)
    {
        return $"عبارة من نوع {target.GetValue()} غير مسموحة في هذا السياق";
    }

    private static string GenerateEnglishMessage(DataType target)
    {
        return $"Illegal expression type found: {target.GetValue()}";
    }
}