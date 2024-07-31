using Common.Application;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.CategoryAgg;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var child = await _repository.GetTracking(request.ParrentId);
            if (child == null)
                return OperationResult.NotFound();
            child.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
