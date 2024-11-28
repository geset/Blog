using System;

namespace LinkDotNet.Blog.Domain;

public sealed class Skill : Entity
{
    private Skill(string name, string? iconUrl, string capability, ProficiencyLevel proficiencyLevel)
    {
        IconUrl = iconUrl;
        Name = name;
        Capability = capability;
        ProficiencyLevel = proficiencyLevel;
    }

    public string? IconUrl { get; private set; }

    public string Name { get; private set; }

    public string Capability { get; private set; }

    public ProficiencyLevel ProficiencyLevel { get; private set; }
    public string ProfileId { get; set; }
    public PersonalProfile Profile { get; set; }

    public static Skill Create(string name, string? iconUrl, string capability, string proficiencyLevel, string profileId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(capability);
        ArgumentException.ThrowIfNullOrWhiteSpace(profileId);

        var level = ProficiencyLevel.Create(proficiencyLevel);

        iconUrl = string.IsNullOrWhiteSpace(iconUrl) ? null : iconUrl;
        return new Skill(name.Trim(), iconUrl, capability.Trim(), level)
        {
            ProfileId = profileId
        };
    }

    public void SetProficiencyLevel(ProficiencyLevel level)
    {
        ArgumentNullException.ThrowIfNull(level);
        ProficiencyLevel = level;
    }
}
