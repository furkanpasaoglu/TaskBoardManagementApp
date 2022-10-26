using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Application.Issues.Constants;
public class IssueMessages
{
    public const string MinTitleLengthMessage = "Title must be at least 12 characters!";
    public const string TitleCannotBeEmpty = "Title cannot be empty!";
    public const string IdCannotBeEmpty = "Id cannot be empty!";
    public const string IssueNumberCannotBeDuplicated = "Issue number cannot be duplicated!";
    public const string IssueTitleAlreadyUpdated = "Issue title already updated!";
    public const string IssueIsNotFound = "Issue is not found!";
}
