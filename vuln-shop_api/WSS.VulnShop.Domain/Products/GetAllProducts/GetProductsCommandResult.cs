﻿namespace WSS.VulnShop.Domain.Products.GetAllProducts
{
    public class GetProductsCommandResult
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public double Price { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public string Image { get; init; }
        public Rating Rating { get; init; }
    }
}
