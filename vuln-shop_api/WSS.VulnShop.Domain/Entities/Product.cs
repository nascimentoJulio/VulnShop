namespace WSS.VulnShop.Domain.Entities
{
    public class Product
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public double Price { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public string Image { get; init; }
    }
}
