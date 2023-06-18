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
    }
}
