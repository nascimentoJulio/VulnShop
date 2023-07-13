using System.Text.Json.Serialization;

namespace WSS.VulnShop.Domain.WishList.AddInWishList
{
    public class AddInWishListCommand : BaseRequest<int>
    {
        [JsonIgnore]
        public string Email { get; init; } = string.Empty;

        public int ProductId { get; init; }

        public int Quantity { get; init; }
    }
}
