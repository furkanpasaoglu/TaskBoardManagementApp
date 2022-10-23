using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Infrastructure.Persistence.Configurations;
public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(x=>x.ProjectId)
            .HasColumnName("ProjectId")
            .IsRequired();

        builder.Property(x => x.AssigneeId)
           .HasColumnName("AssigneeId")
           .IsRequired();
        
        builder.Property(x => x.ReporterId)
           .HasColumnName("ReporterId")
           .IsRequired();
        
        builder.Property(x => x.Number)
           .HasColumnName("Number")
           .IsRequired();
        
        builder.Property(x => x.Name)
           .HasColumnName("Name")
           .IsRequired();
        
        builder.Property(x => x.Types)
           .HasColumnName("Types")
           .IsRequired();
        
        builder.Property(x => x.Status)
           .HasColumnName("Status")
           .IsRequired(); 
        
        builder.Property(x => x.DueDate)
           .HasColumnName("DueDate")
           .IsRequired();
    }
}
