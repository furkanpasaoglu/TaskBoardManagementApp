using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Constants;
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
          .HasMaxLength(IssueDetailConsts.MaxDescriptionLength)
          .IsRequired();

        builder.Property(x => x.Comments)
          .HasColumnName("Comments")
          .HasMaxLength(IssueDetailConsts.MaxCommentLength)
          .IsRequired();
    }
}
