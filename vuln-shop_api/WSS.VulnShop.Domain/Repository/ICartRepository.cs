using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Repository
{
    public interface ICartRepository : IBaseRepository<ProductsInCart>
    {
        Task<bool> ProductAlreadyAdded(int productId, string email);

        Task IncrementProduct(int productId, int quantity, string email);
        
        Task DecrementProduct(int productId, int quantity, string email);

        Task DeleteCartItem(int productId, string email);

        Task<int> GetQuantityItemInCart(int productId, string email);

        Task<int> InsertCart(int productId, int quantity, string email);
    }
}
