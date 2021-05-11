using Core.Attributes;
using Xunit;

namespace Test.CoreTest
{
    public class AttributesTest
    {
        [Fact]
        public void TestColumnAttribute()
        {
            ColumnAttribute attribute = new ColumnAttribute("Test", true);

            Assert.Equal("Test", attribute.Title);
            Assert.True(attribute.Visible);
        }
    }
}
