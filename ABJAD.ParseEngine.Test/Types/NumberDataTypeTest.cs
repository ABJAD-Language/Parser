using ABJAD.ParseEngine.Types;
using Xunit;

namespace ABJAD.ParseEngine.Test.Types;

public class NumberDataTypeTest
{
    [Fact]
    private void ReturnsNumberValue()
    {
        Assert.Equal("NUMBER", new NumberDataType().GetValue());
    }

    [Fact(DisplayName = "returns true when comparing two number data types")]
    public void returns_true_when_comparing_two_number_data_types()
    {
        Assert.True(new NumberDataType().Equals(new NumberDataType()));
    }
}