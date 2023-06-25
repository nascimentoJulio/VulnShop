using MediatR;

namespace WSS.VulnShop.Domain.Cart.GetCart
{
    public class GetCartCommand : BaseRequest, IRequest<GetCartCommandResult>
    {
        public string Email { get; set; }
    }
}
