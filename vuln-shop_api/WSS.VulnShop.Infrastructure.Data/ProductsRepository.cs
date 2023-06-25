using Dapper;
using Microsoft.Extensions.Configuration;
using WSS.VulnShop.Domain.Entities;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Infrastructure.Data
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IConfiguration configuration) : base(configuration, "products")
        {
        }

        public async Task<IEnumerable<ProductsInCart>> GetProductsInCart(string email)
        {
            return await _conn.QueryAsync<ProductsInCart>(@"select * from carts c inner join products p ON c.id_product = p.id  
                                                            where c.email_user = @Email", new { Email = email });
        }
    }
}
