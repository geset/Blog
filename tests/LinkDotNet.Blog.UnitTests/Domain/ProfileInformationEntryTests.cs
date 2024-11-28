using System;
using LinkDotNet.Blog.Domain;

namespace LinkDotNet.Blog.UnitTests.Domain;

public class ProfileInformationEntryTests
{
    private const string TestProfileId = "testProfileId";

    [Fact]
    public void ShouldCreateObject()
    {
        var result = ProfileInformationEntry.Create("key", 12, TestProfileId);

        result.Content.ShouldBe("key");
        result.SortOrder.ShouldBe(12);
        result.ProfileId.ShouldBe(TestProfileId);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null!)]
    public void ShouldThrowExceptionWhenEmptyKeyOrValue(string? content)
    {
        Action act = () => ProfileInformationEntry.Create(content!, 0, TestProfileId);

        act.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void ShouldTrim()
    {
        var result = ProfileInformationEntry.Create("   key ", 0, TestProfileId);

        result.Content.ShouldBe("key");
    }
}
