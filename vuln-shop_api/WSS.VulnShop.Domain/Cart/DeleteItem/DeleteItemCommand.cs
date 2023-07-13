using MediatR;
using System.Text.Json.Serialization;

namespace WSS.VulnShop.Domain.Cart.DeleteItem
{
    public class DeleteItemCommand : BaseRequest<int>
    {
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public string Email { get; set; } = string.Empty;
    }
}
