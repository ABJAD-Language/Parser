using ABJAD.ParseEngine.Types;
using Xunit;

namespace ABJAD.ParseEngine.Test.Types;

public class StringDataTypeTest
{
    [Fact]
    private void ReturnsStringValue()
    {
        Assert.Equal("STRING", new StringDataType().GetValue());
    }

    [Fact]
    private void ReturnsTrueOnEqualCheckWithStringDataType()
    {
        Assert.True(new StringDataType().Equals(new StringDataType()));
    }
}