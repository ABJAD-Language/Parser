using ABJAD.ParseEngine.Types;
using Xunit;

namespace ABJAD.ParseEngine.Test.Types;

public class BoolDataTypeTest
{
    [Fact]
    private void ReturnsBoolValue()
    {
        Assert.Equal("BOOL", new BoolDataType().GetValue());
    }

    [Fact(DisplayName = "returns true when comparing two boolean data types")]
    public void returns_true_when_comparing_two_boolean_data_types()
    {
        Assert.True(new BoolDataType().Equals(new BoolDataType()));
    }
}
