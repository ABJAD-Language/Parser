using ABJAD.ParseEngine.Primitives;
using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions.Assignments;

public abstract class BinaryAssignmentExpression : Expression
{
    protected BinaryAssignmentExpression(IdentifierPrimitive target, Expression value)
    {
        Target = target;
        Value = value;
    }

    public IdentifierPrimitive Target { get; }
    public Expression Value { get; }

    public DataType GetDataType()
    {
        return DataType.Void();
    }
}