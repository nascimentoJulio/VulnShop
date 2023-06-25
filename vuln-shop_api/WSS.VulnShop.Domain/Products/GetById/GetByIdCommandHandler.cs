using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Products.GetById
{
    public class GetByIdCommandHandler : IRequestHandler<GetByIdCommand, GetByIdCommandResult>
    {
        private readonly IProductsRepository _productsRepository;    
        public GetByIdCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<GetByIdCommandResult> Handle(GetByIdCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) throw new ArgumentException("Parâmetros inválidos");

            var result = await _productsRepository.GetById(request.Id);

            return new GetByIdCommandResult
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Image = result.Image,
                Price = result.Price,
                Category = result.Category
            };
        }
    }
}
