using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Cart.AddInCart
{
    public class AddInCartCommandHandler : IRequestHandler<AddInCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public AddInCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(AddInCartCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ArgumentException("Parâmetros inválidos");

            var alreadyAdded = await _cartRepository.ProductAlreadyAdded(request.ProductId, request.Email);
            if (alreadyAdded)
            {
                await _cartRepository.IncrementProduct(request.ProductId, request.Quantity, request.Email);
                return request.ProductId;
            }
            return await _cartRepository.InsertCart(request.ProductId, request.Quantity, request.Email);
        }
    }
}
