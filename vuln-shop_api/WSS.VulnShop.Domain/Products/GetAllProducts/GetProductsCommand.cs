using MediatR;

namespace WSS.VulnShop.Domain.Products.GetAllProducts
{
    public class GetProductsCommand : BaseRequest<List<GetProductsCommandResult>>
    {
        public int Limit { get; init; }

        public int Page { get; init; }

        public override bool IsValid()
        {
            return Limit > 0 && Page > 0;
        }
    }
}
