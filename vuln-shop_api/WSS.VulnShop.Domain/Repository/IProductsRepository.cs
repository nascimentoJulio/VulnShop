﻿using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Repository
{
    public interface IProductsRepository: IBaseRepository<Product>
    {
        Task<IEnumerable<ProductsInCart>> GetProductsInCart(string email);
    }
}
