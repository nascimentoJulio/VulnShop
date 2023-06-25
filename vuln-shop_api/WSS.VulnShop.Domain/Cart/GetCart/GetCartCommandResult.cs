using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Cart.GetCart
{
    public class GetCartCommandResult
    {
        public IEnumerable<ProductsInCart> Products{ get; set; }

        public decimal Total { get; set; }
    }
}
