using LinkDotNet.Blog.Domain;
using System;

namespace LinkDotNet.Blog.TestUtilities;

public class SkillBuilder
{
    private string type = "Lecture";
    private string title = "C# Basics";
    private DateTime date = DateTime.Now;
    private string venueOrPublisher = "Online";
    private string description = "Introduction to C#";
    private string profileId = "defaultProfileId"; // Default value for testing

    public SkillBuilder WithType(string type)
    {
        this.type = type;
        return this;
    }

    public SkillBuilder WithTitle(string title)
    {
        this.title = title;
        return this;
    }

    public SkillBuilder WithDate(DateTime date)
    {
        this.date = date;
        return this;
    }

    public SkillBuilder WithVenueOrPublisher(string venueOrPublisher)
    {
        this.venueOrPublisher = venueOrPublisher;
        return this;
    }

    public SkillBuilder WithDescription(string description)
    {
        this.description = description;
        return this;
    }

    public SkillBuilder WithProfileId(string profileId)
    {
        this.profileId = profileId;
        return this;
    }

    public Skill Build()
    {
        return Skill.Create(type, title, date, venueOrPublisher, description, profileId);
    }
}
