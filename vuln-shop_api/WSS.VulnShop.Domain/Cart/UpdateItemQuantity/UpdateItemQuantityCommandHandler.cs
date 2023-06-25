using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.Cart.UpdateItemQuantity
{
    public class UpdateItemQuantityCommandHandler : IRequestHandler<UpdateItemQuantityCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateItemQuantityCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) throw new ArgumentException("Parâmetros inválidos");

            if (request.operation == QuantityOperation.INCREMENT)
            {
                await _cartRepository.IncrementProduct(request.ProductId, request.Quantity, request.Email);
            }
            else
            {
                var cartQuantity = await _cartRepository.GetQuantityItemInCart(request.ProductId, request.Email);
                if ((cartQuantity - request.Quantity) <= 0)
                {
                    await _cartRepository.DeleteCartItem(request.ProductId, request.Email);
                }
                else
                {
                    await _cartRepository.DecrementProduct(request.ProductId,
                                                           request.Quantity,
                                                           request.Email);
                }
            }
            return request.ProductId;
        }
    }
}
