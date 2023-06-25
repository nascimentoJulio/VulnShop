using Dapper;
using Microsoft.Extensions.Configuration;
using WSS.VulnShop.Domain.Entities;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Infrastructure.Data
{
    public class CartRepository : BaseRepository<ProductsInCart>, ICartRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration, "carts")
        {
        }

        public async Task<bool> ProductAlreadyAdded(int productId, string email)
        {
            var result = await _conn.QueryFirstAsync<int>(@"select count(*) from carts c
                                                            where c.id_product = @ProductId and c.email_user = @Email", new { ProductId = productId, Email = email });
            return result > 0;
        }

        public async Task IncrementProduct(int productId, int quantity, string email)
        {
            await _conn.ExecuteAsync(@"update carts 
                                       set quantity = quantity + @Quantity
                                       where email_user = @Email and id_product = @ProductId", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task<int> InsertCart(int productId, int quantity, string email)
        {
            return await _conn.QueryFirstAsync<int>(@"INSERT INTO public.carts
                                                         (email_user, id_product, quantity)
                                                      VALUES
                                                         (@Email, @ProductId, @Quantity)
                                                      RETURNING id;", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task DecrementProduct(int productId, int quantity, string email)
        {
            await _conn.ExecuteAsync(@"update carts 
                                       set quantity = quantity - @Quantity
                                       where email_user = @Email and id_product = @ProductId", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task<int> GetQuantityItemInCart(int productId, string email)
        {
            return await _conn.QueryFirstAsync<int>(@"select c.quantity from carts c
                                                      where c.id_product = @ProductId and c.email_user = @Email", new { ProductId = productId, Email = email });
        }

        public async Task DeleteCartItem(int productId, string email)
        {
            await _conn.ExecuteAsync(@"delete from carts c
                                       where c.id_product = @ProductId and c.email_user = @Email", new { ProductId = productId, Email = email });
        }
    }
}
