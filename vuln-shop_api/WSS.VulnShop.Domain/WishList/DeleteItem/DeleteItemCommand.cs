using System.Text.Json.Serialization;

namespace WSS.VulnShop.Domain.WishList.DeleteItem
{
    public class DeleteItemCommand : BaseRequest<int>
    {
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public string Email { get; set; } = string.Empty;
    }
}
