using WSS.VulnShop.Domain.Entities;

namespace WSS.VulnShop.Domain.Products.GetById
{
    public class GetByIdCommandResult
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public string Image { get; init; }
        public Rating Rating { get; init; }
    }
}
