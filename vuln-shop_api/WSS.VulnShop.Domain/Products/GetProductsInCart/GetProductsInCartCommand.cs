using MediatR;

namespace WSS.VulnShop.Domain.Products.GetProductsInCart
{
    public class GetProductsInCartCommand : IRequest<GetProductsInCartCommandResult>
    {
       public string Email { get; set; }
    }
}
