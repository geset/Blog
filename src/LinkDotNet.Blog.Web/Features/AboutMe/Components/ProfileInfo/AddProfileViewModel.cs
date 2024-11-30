using System.ComponentModel.DataAnnotations;

namespace LinkDotNet.Blog.Web.Features.AboutMe.Components.ProfileInfo;

public class AddProfileViewModel
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
}
