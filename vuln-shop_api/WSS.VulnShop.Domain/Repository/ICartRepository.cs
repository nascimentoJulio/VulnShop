using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Repository
{
    public interface ICartRepository : IBaseRepository<ProductsInCart>
    {
        Task<bool> ProductAlreadyAdded(int productId, string email);

        Task IncrementProduct(int productId, int quantity, string email);

        Task<int> InsertCart(int productId, int quantity, string email);
    }
}
