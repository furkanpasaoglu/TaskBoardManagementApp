using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Constants;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Infrastructure.Persistence.Configurations;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(x => x.ProjectName)
            .HasColumnName("ProjectName")
            .IsRequired();
    }
}
