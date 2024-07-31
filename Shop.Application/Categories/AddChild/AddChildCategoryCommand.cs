using Common.Application;
using Common.Domain.ValueObject;
using Shop.Application.Categories.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParrentId, string Title, string Slug, SeoData SeoData) : IBaseCommand;
}
