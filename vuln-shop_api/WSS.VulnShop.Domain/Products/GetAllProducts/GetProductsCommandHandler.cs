using MediatR;
using WSS.VulnShop.Domain.Entities;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Products.GetAllProducts
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, List<GetProductsCommandResult>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<GetProductsCommandResult>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetPaginated(request.Limit, request.Page);

            return result.Select(product => new GetProductsCommandResult
            {
                Id = product.Id,
                Category = product.Category,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Title = product.Title
            }).ToList();
        }
    }
}
