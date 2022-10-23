using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Infrastructure.Persistence.Configurations;

public class WorkLogConfiguration : IEntityTypeConfiguration<WorkLog>
{
    public void Configure(EntityTypeBuilder<WorkLog> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired(); 
        
        builder.Property(x => x.IssueId)
            .HasColumnName("IssueId")
            .IsRequired();
        
        builder.Property(x => x.Log)
            .HasColumnName("Log")
            .IsRequired();
    }
}
