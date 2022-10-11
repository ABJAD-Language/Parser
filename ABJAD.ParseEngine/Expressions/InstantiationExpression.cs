using ABJAD.ParseEngine.Types;

namespace ABJAD.ParseEngine.Expressions;

public class InstantiationExpression : Expression
{
    public InstantiationExpression(PrimitiveExpression @class, List<Expression> arguments)
    {
        Class = @class;
        Arguments = arguments;
    }

    public PrimitiveExpression Class { get; }
    public List<Expression> Arguments { get; }

    public DataType GetDataType()
    {
        throw new NotImplementedException();
    }
}