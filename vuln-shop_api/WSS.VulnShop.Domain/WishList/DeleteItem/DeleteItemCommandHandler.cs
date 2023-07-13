using MediatR;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Domain.WishList.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, int>
    {
        public IWishListRepository _wishListRepository { get; set; }

        public DeleteItemCommandHandler(IWishListRepository wishList)
        {
            _wishListRepository = wishList;
        }

        public async Task<int> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ArgumentException("Parâmetros inválidos");

            var productIsAdded = await _wishListRepository.ProductAlreadyAdded(request.ProductId, request.Email);

            if (!productIsAdded)
                throw new FileNotFoundException();
            else
                await _wishListRepository.DeleteCartItem(request.ProductId, request.Email);

            return 1;
        }
    }
}
