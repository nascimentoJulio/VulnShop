using MediatR;

namespace WSS.VulnShop.Domain.Products.GetAllProducts
{
    public class GetProductsCommand : IRequest<List<GetProductsCommandResult>>
    {
        public int Limit { get; init; }

        public int Page { get; init; }
    }
}
