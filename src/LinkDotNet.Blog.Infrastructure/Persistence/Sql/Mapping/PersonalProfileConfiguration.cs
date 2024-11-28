using LinkDotNet.Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDotNet.Blog.Infrastructure.Persistence.Sql.Mapping;

public class PersonalProfileConfiguration : IEntityTypeConfiguration<PersonalProfile>
{
    public void Configure(EntityTypeBuilder<PersonalProfile> builder)
    {
        builder.ToTable("PersonalProfiles");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Ignore(p => p.FullName);

        builder.HasMany(p => p.Skills)
            .WithOne(s => s.Profile)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Talk)
            .WithOne(t => t.Profile)
            .HasForeignKey<Talk>(t => t.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.ProfileInformationEntries)
            .WithOne(e => e.Profile)
            .HasForeignKey(e => e.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

