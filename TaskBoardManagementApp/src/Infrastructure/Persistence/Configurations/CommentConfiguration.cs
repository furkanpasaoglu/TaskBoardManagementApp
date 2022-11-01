using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardManagementApp.Domain.Constants;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Infrastructure.Persistence.Configurations;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(x => x.ProjectId)
            .HasColumnName("ProjectId")
            .IsRequired();

        builder.Property(x => x.IssueId)
            .HasColumnName("IssueId")
            .IsRequired();

        builder.Property(x => x.Message)
            .HasColumnName("Message")
            .HasMaxLength(CommentConsts.MaxCommentLength)
            .IsRequired();
    }
}
