using Common.Application;
using Shop.Application.Comments.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Domain.CommentAgg.Comment;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeStatusCommentCommand(long Id , CommentStatus Status) : IBaseCommand;
}
