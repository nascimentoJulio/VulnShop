using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Products.GetProductsInCart
{
    public class GetProductsInCartCommandResult
    {
        public IEnumerable<ProductsInCart> Products { get; set; }
    }
}