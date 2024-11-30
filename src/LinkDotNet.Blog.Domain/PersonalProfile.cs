using LinkDotNet.Blog.Domain;
using System;
using System.Collections.Generic;

namespace LinkDotNet.Blog.Domain;
public sealed class PersonalProfile : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public ICollection<Skill> Skills { get; private set; } = new List<Skill>();
    public Talk Talk { get; private set; }
    public ICollection<ProfileInformationEntry> ProfileInformationEntries { get; private set; } = new List<ProfileInformationEntry>();

    private PersonalProfile() { }

    public static PersonalProfile Create(string firstName, string lastName)
    {
        return new PersonalProfile
        {
            FirstName = firstName,
            LastName = lastName
        };
    }

    public void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
