using ABJAD.ParseEngine.Types;
using Xunit;

namespace ABJAD.ParseEngine.Test.Types;

public class CustomDataTypeTest
{
    [Fact]
    private void ReturnsCustomValue()
    {
        Assert.Equal("CustomValue", new CustomDataType("CustomValue").GetValue());
    }

    [Fact(DisplayName = "returns true when comparing two custom data types with the same value")]
    public void returns_true_when_comparing_two_custom_data_types_with_the_same_value()
    {
        Assert.True(new CustomDataType("value").Equals(new CustomDataType("value")));
    }

    [Fact(DisplayName = "returns false when comparing two custom data types with different values")]
    public void returns_false_when_comparing_two_custom_data_types_with_different_values()
    {
        Assert.False(new CustomDataType("value").Equals(new CustomDataType("anotherValue")));
    }
}