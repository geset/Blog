using System.Collections.Generic;

namespace LinkDotNet.Blog.Domain;

public sealed record ProfileInformation
{
    public const string ProfileInformationSection = "ProfileInformation";

    public string Name { get; init; }
    public string Heading { get; init; }
    public string ProfilePictureUrl { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName { get; init; }
    public List<ProfileInformationEntry> ProfileInformationEntries { get; init; } = new();
}
