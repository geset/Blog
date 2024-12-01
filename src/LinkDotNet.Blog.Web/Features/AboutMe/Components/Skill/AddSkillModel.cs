using System;
using System.ComponentModel.DataAnnotations;
using LinkDotNet.Blog.Domain;

namespace LinkDotNet.Blog.Web.Features.AboutMe.Components.Skill;

public sealed class AddSkillModel
{
    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string VenueOrPublisher { get; set; } = string.Empty;
    public string? Url { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;
}
