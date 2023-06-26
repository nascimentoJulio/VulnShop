using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Cart.DeleteItem
{
    public class DeleteCommandHandler : IRequestHandler<DeleteItemCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ArgumentException("Parâmetros inválidos");

            var productIsAdded = await _cartRepository.ProductAlreadyAdded(request.ProductId, request.Email);

            if (!productIsAdded)
                throw new FileNotFoundException();
            else
               await _cartRepository.DeleteCartItem(request.ProductId, request.Email);

            return 1;
        }
    }
}
