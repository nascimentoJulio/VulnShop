using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Products.GetProductsInCart
{
    public class GetProductsInCartCommandHandler : IRequestHandler<GetProductsInCartCommand, GetProductsInCartCommandResult>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsInCartCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<GetProductsInCartCommandResult> Handle(GetProductsInCartCommand request, CancellationToken cancellationToken)
        {
            var result = new GetProductsInCartCommandResult();
            result.Products = await _productsRepository.GetProductsInCart(request.Email);

            return result;
        }
    }
}
