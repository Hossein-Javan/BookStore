using Common.Application;
using Shop.Application.Categories.Edit;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Comments.Create;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long CommentId,string Text, long UserId, long ProductId) : IBaseCommand;
}
