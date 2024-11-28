using LinkDotNet.Blog.Domain;
using System.Collections.Generic;

namespace LinkDotNet.Blog.Domain;
public sealed class PersonalProfile : Entity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName => $"{FirstName} {LastName}";
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public Talk Talk { get; set; }
    public ICollection<ProfileInformationEntry> ProfileInformationEntries { get; set; } = new List<ProfileInformationEntry>();
}
