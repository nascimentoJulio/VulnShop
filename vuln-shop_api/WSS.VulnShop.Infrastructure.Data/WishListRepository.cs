using Dapper;
using Microsoft.Extensions.Configuration;
using WSS.VulnShop.Domain.Entities;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Infrastructure.Data
{
    public class WishListRepository : BaseRepository<WishListProduct>,  IWishListRepository
    {
        public WishListRepository(IConfiguration configuration) : base(configuration, "wish_lists")
        {
        }

        public async Task<bool> ProductAlreadyAdded(int productId, string email)
        {
            var result = await _conn.QueryFirstAsync<int>(@"select count(*) from wish_lists
                                                            where id_product = @ProductId and email_user = @Email", new { ProductId = productId, Email = email });
            return result > 0;
        }

        public async Task IncrementProduct(int productId, int quantity, string email)
        {
            await _conn.ExecuteAsync(@"update wish_lists
                                       set quantity = quantity + @Quantity
                                       where email_user = @Email and id_product = @ProductId", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task<int> InsertCart(int productId, int quantity, string email)
        {
            return await _conn.QueryFirstAsync<int>(@"INSERT INTO wish_lists
                                                         (email_user, id_product, quantity)
                                                      VALUES
                                                         (@Email, @ProductId, @Quantity)
                                                      RETURNING id;", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task DecrementProduct(int productId, int quantity, string email)
        {
            await _conn.ExecuteAsync(@"update wish_lists 
                                       set quantity = quantity - @Quantity
                                       where email_user = @Email and id_product = @ProductId", new { ProductId = productId, Quantity = quantity, Email = email });
        }

        public async Task<int> GetQuantityItemInCart(int productId, string email)
        {
            return await _conn.QueryFirstAsync<int>(@"select quantity from wish_lists
                                                      where  id_product = @ProductId and email_user = @Email", new { ProductId = productId, Email = email });
        }

        public async Task DeleteCartItem(int productId, string email)
        {
            await _conn.ExecuteAsync(@"delete from wish_lists
                                       where id_product = @ProductId and email_user = @Email", new { ProductId = productId, Email = email });
        }
    }
}
