using LinkDotNet.Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDotNet.Blog.Infrastructure.Persistence.Sql.Mapping;

internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .IsUnicode(false)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Type)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(s => s.Title)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(s => s.Date)
            .IsRequired();

        builder.Property(s => s.VenueOrPublisher)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(1024)
            .IsRequired();

        builder.HasOne(e => e.Profile)
              .WithMany(p => p.Skills)
              .HasForeignKey(e => e.ProfileId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
