using MediatR;

namespace WSS.VulnShop.Domain.Cart.GetCart
{
    public class GetCartCommand : BaseRequest<GetCartCommandResult>
    {
        public string Email { get; set; }
    }
}
