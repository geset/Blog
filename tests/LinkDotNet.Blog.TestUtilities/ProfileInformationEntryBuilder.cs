using LinkDotNet.Blog.Domain;

namespace LinkDotNet.Blog.TestUtilities;

public class ProfileInformationEntryBuilder
{
    private string content = "Content";
    private int sortOrder;
    private string profileId = "defaultProfileId"; // Default value for profileId

    public ProfileInformationEntryBuilder WithContent(string key)
    {
        content = key;
        return this;
    }

    public ProfileInformationEntryBuilder WithSortOrder(int sortOrder)
    {
        this.sortOrder = sortOrder;
        return this;
    }

    public ProfileInformationEntryBuilder WithProfileId(string profileId)
    {
        this.profileId = profileId;
        return this;
    }

    public ProfileInformationEntry Build()
    {
        return ProfileInformationEntry.Create(content, sortOrder, profileId);
    }
}
