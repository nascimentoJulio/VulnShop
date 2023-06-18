using MediatR;

namespace WSS.VulnShop.Domain.Products.GetAllProducts
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, List<GetProductsCommandResult>>
    {
        public Task<List<GetProductsCommandResult>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var mockList = new List<GetProductsCommandResult>()
            {
                new GetProductsCommandResult
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price = 109.95,
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                    Category = "men's clothing",
                    Image = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
                    Rating = new Rating
                    {
                        Rate = 3.9,
                        Count = 120
                    }
                }
            };
            return Task.FromResult(mockList);
        }
    }
}
