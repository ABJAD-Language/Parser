using ABJAD.ParseEngine.Primitives;
using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions;

public class PrimitiveExpression : Expression
{
    public PrimitiveExpression(Primitive primitive)
    {
        Primitive = primitive;
    }

    public Primitive Primitive { get; }

    public DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}