using MediatR;
using WSS.VulnShop.Domain.Products.GetProductsInCart;

namespace WSS.VulnShop.Domain.Cart.GetCart
{
    public class GetCartCommandHandler : IRequestHandler<GetCartCommand, GetCartCommandResult>
    {
        private readonly IMediator _mediator;

        public GetCartCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetCartCommandResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) throw new ArgumentNullException("Parâmetros inválidos");

            var command = new GetProductsInCartCommand { Email = request.Email };
            var result = await _mediator.Send(command);

            return new GetCartCommandResult()
            {
                Products = result?.Products,
                Total = result.Products is not null? result.Products.Select(p => p.Price * p.Quantity)
                                                                .Aggregate((acc, crr) => acc + crr) : 0
            };
        }
    }
}
