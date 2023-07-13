using MediatR;
using System.Text.Json.Serialization;

namespace WSS.VulnShop.Domain.Cart.AddInCart
{
    public class AddInCartCommand : BaseRequest<int>
    {
        [JsonIgnore]
        public string Email { get; set; } = string.Empty;

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
