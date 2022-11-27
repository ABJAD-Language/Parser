using ABJAD.ParseEngine.Types;
using Xunit;

namespace ABJAD.ParseEngine.Test.Types;

public class VoidDataTypeTest
{
    [Fact]
    private void ReturnsVoidValue()
    {
        Assert.Equal("VOID", new VoidDataType().GetValue()); 
    }

    [Fact(DisplayName = "returns true when comparing two void data types")]
    public void returns_true_when_comparing_two_void_data_types()
    {
        Assert.True(new VoidDataType().Equals(new VoidDataType()));
    }
}