using System;

namespace LinkDotNet.Blog.Domain;

public sealed class Skill : Entity
{
    private Skill(string type, string title, DateTime date, string venueOrPublisher, string description)
    {
        Type = type;
        Title = title;
        Date = date;
        VenueOrPublisher = venueOrPublisher;
        Description = description;
    }

    public string Type { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public string VenueOrPublisher { get; private set; }
    public string Description { get; private set; }
    public string ProfileId { get; private set; }
    public PersonalProfile Profile { get; private set; }

    public static Skill Create(string type, string title, DateTime date, string venueOrPublisher, string description, string profileId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(venueOrPublisher);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(profileId);

        return new Skill(type.Trim(), title.Trim(), date, venueOrPublisher.Trim(), description.Trim())
        {
            ProfileId = profileId
        };
    }

    public void Update(string type, string title, DateTime date, string venueOrPublisher, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(venueOrPublisher);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        Type = type.Trim();
        Title = title.Trim();
        Date = date;
        VenueOrPublisher = venueOrPublisher.Trim();
        Description = description.Trim();
    }
}
