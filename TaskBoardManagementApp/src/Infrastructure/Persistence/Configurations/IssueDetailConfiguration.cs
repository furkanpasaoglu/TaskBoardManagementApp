using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Infrastructure.Persistence.Configurations;

public class IssueDetailConfiguration : IEntityTypeConfiguration<IssueDetail>
{
    public void Configure(EntityTypeBuilder<IssueDetail> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(x => x.IssueId)
          .HasColumnName("IssueId")
          .IsRequired(); 
        
        builder.Property(x => x.Description)
          .HasColumnName("Description")
          .IsRequired();

        builder.Property(x => x.Comments)
          .HasColumnName("Comments")
          .IsRequired();
    }
}
