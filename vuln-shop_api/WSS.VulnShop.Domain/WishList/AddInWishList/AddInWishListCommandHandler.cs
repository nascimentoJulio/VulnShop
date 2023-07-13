using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.WishList.AddInWishList
{
    public class AddInWishListCommandHandler : IRequestHandler<AddInWishListCommand, int>
    {
        public IWishListRepository _wishListRepository { get; set; }

        public AddInWishListCommandHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<int> Handle(AddInWishListCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ArgumentException("Parâmetros inválidos");

            var alreadyAdded = await _wishListRepository.ProductAlreadyAdded(request.ProductId, request.Email);
            if (alreadyAdded)
            {
                await _wishListRepository.IncrementProduct(request.ProductId, request.Quantity, request.Email);
                return request.ProductId;
            }
            return await _wishListRepository.InsertCart(request.ProductId, request.Quantity, request.Email);

        }
    }
}
