using Common.Application;
using Common.Domain.ValueObject;
using Shop.Application.Categories.Edit;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand( string Text, long UserId, long ProductId) : IBaseCommand;

}
