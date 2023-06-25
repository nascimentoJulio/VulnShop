using MediatR;
using System.Text.Json.Serialization;

namespace WSS.VulnShop.Domain.Cart.UpdateItemQuantity
{
    public class UpdateItemQuantityCommand : BaseRequest, IRequest<int>
    {
        public int ProductId { get; set; }

        [JsonIgnore]
        public string Email { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public QuantityOperation operation { get; set; }
    }

    public enum QuantityOperation
    {
        INCREMENT, DECREMENT
    }
}
