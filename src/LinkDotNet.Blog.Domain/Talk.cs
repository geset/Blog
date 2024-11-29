using System;

namespace LinkDotNet.Blog.Domain;

public sealed class Talk : Entity
{
    public string PresentationTitle { get; private set; } = default!;
    public string Place { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string ProfileId { get; set; }
    public PersonalProfile Profile { get; set; }
    public DateTime PublishedDate { get; private set; }

    public static Talk Create(string presentationTitle, string place, string description, DateTime publishedDate, string profileId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(presentationTitle);
        ArgumentException.ThrowIfNullOrWhiteSpace(place);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(profileId);

        return new Talk
        {
            PresentationTitle = presentationTitle.Trim(),
            PublishedDate = publishedDate,
            Place = place.Trim(),
            Description = description.Trim(),
            ProfileId = profileId
        };
    }

    public void Update(string presentationTitle, string place, string description, DateTime publishedDate)
    {
        PresentationTitle = presentationTitle;
        Place = place;
        Description = description;
        PublishedDate = publishedDate;
    }
}
