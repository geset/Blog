using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinkDotNet.Blog.Domain;

[DebuggerDisplay("{Content} with sort order {SortOrder}")]
public sealed class ProfileInformationEntry : Entity
{
    public string Content { get; private init; } = default!;
    public int SortOrder { get; set; }
    public string ProfileId { get; set; }
    public PersonalProfile Profile { get; set; }

    public static ProfileInformationEntry Create(string key, int sortOrder, string profileId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentException.ThrowIfNullOrWhiteSpace(profileId);

        return new ProfileInformationEntry
        {
            Content = key.Trim(),
            SortOrder = sortOrder,
            ProfileId = profileId
        };
    }
}
